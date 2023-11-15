using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventorySlotPrefab;
    public Transform inventoryPanel_Elena;
    public Transform inventoryPanel_Warrior;

    public Elena elenaCharacter;
    public Warrior warriorCharacter;

    private Dictionary<string, List<Item>> characterInventories = new Dictionary<string, List<Item>>();

    private bool isUpdatingHealth = false;

     void Start()
    {
        // Envantarı güncelleyin
        UpdateInventoryUI();
        // Karakterlerin canını güncelle
        StartCoroutine(UpdateCharacterHealthCoroutine());
        //InvokeRepeating("UpdateCharacterHealth", 1.0f, 1.0f); // Her 2 saniyede bir can güncelle
    }

    private IEnumerator UpdateCharacterHealthCoroutine()
    {
        isUpdatingHealth = true;

        foreach (var characterInventory in characterInventories.Values)
        {
            foreach (Item item in characterInventory)
            {
                if (item.itemType == Item.ItemType.Weapon)
                {
                    Weapon weapon = item as Weapon;
                    weapon.UseItem(characterInventory == characterInventories["Elena"] ? elenaCharacter : warriorCharacter);
                }
                else if (item.itemType == Item.ItemType.Potion)
                {
                    Potion potion = item as Potion;
                    potion.UseItem(characterInventory == characterInventories["Elena"] ? elenaCharacter : warriorCharacter);
                }
                // Her öğenin işlenmesi arasında 1 saniye bekle
                yield return new WaitForSeconds(1.0f);
            }
            // Karakterin sağlığını güncelle
           UpdateCharacterHealth(characterInventory == characterInventories["Elena"] ? elenaCharacter : warriorCharacter, characterInventory);
           UpdateCharacterHealth(elenaCharacter, characterInventories["Elena"]);
           UpdateCharacterHealth(warriorCharacter, characterInventories["Warrior"]);
    
            }

        isUpdatingHealth = false;
    }

    private void AddItemToInventory(string characterName, Item item)
    {
        if (!characterInventories.ContainsKey(characterName))
        {
            characterInventories[characterName] = new List<Item>();
        }

        characterInventories[characterName].Add(item);
    }


    private void UpdateCharacterHealth(Character character, List<Item> inventory)
    {
        foreach (Item item in inventory)
        {
            if (item.itemType == Item.ItemType.Weapon)
            {
                Weapon weapon = item as Weapon;
                weapon.UseItem(character);
            }
            else if (item.itemType == Item.ItemType.Potion)
            {
                Potion potion = item as Potion;
                potion.UseItem(character);
            }
        }

         //update health bar
        character.SetHealth(character.GetHealth());
    }

    private void UpdateInventoryUI()
    {
        // Icon ekle
        Sprite swordIcon = Resources.Load<Sprite>("sword_icon");
        Weapon swordW = new Weapon("Sword", 20, 30, swordIcon);

        Sprite axeIcon = Resources.Load<Sprite>("iron_axe");
        Weapon axe = new Weapon("Axe", 30, 30, axeIcon);

        Sprite staffIcon = Resources.Load<Sprite>("staff");
        Weapon staff = new Weapon("Staff", 40, 40, staffIcon);

        Sprite scytheIcon = Resources.Load<Sprite>("scythe");
        Weapon scythe = new Weapon("Scythe", 50, 40, scytheIcon);

        Sprite tridentIcon = Resources.Load<Sprite>("trident");
        Weapon trident = new Weapon("Trident", 60, 50, tridentIcon);

        Sprite healthPotionIcon = Resources.Load<Sprite>("pot7");
        Potion healthPotion = new Potion("Health Potion", 10, healthPotionIcon);

        Sprite healthPotion2Icon = Resources.Load<Sprite>("potx2");
        Potion healthPotion2 = new Potion("Health Potion2", 20, healthPotion2Icon);

        Sprite healthPotion3Icon = Resources.Load<Sprite>("pot4");
        Potion healthPotion3 = new Potion("Health Potion3", 30, healthPotion3Icon);

        Sprite healthPotion4Icon = Resources.Load<Sprite>("pot3");
        Potion healthPotion4 = new Potion("Health Potion4", 40, healthPotion4Icon);   

        Sprite healthPotion5Icon = Resources.Load<Sprite>("pot6");
        Potion healthPotion5 = new Potion("Health Potion5", 50, healthPotion5Icon);


        AddItemToInventory("Elena", swordW);
        AddItemToInventory("Elena", healthPotion);
        AddItemToInventory("Elena", trident);
        AddItemToInventory("Elena", healthPotion3);
        AddItemToInventory("Elena", staff);

        AddItemToInventory("Warrior", axe);
        AddItemToInventory("Warrior", healthPotion2);
        AddItemToInventory("Warrior", scythe);
        AddItemToInventory("Warrior", healthPotion4);
        AddItemToInventory("Warrior", swordW);

         // Elena'nın envanterini güncelle
        UpdatePanel(characterInventories["Elena"], inventoryPanel_Elena);

        // Warrior'ın envanterini güncelle
        UpdatePanel(characterInventories["Warrior"], inventoryPanel_Warrior);
    }

    private void UpdatePanel(List<Item> characterInventory, Transform panel)
    {
        foreach (Transform child in panel)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in characterInventory)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, panel);
            Image itemIcon = slot.GetComponent<Image>();

            if (item != null)
            {
                itemIcon.sprite = item.itemIcon;
            }
        }
    }

}


   
    //private List<Item> characterInventory = new List<Item>();

/*
    void Start()
    {
        //icon ekle
        Sprite swordIcon = Resources.Load<Sprite>("swordIcon");
        Weapon sword = new Weapon("Sword", 20, 30, swordIcon);
        characterInventory.Add(sword);

        Sprite axeIcon = Resources.Load<Sprite>("axeIcon");
        Weapon axe = new Weapon("Axe", 30, 30, axeIcon);
        characterInventory.Add(axe);

        // Envantarı güncelleyin
        UpdateInventoryUI();
}
*/

/*
    private void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in characterInventory)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel);
            Image itemIcon = slot.GetComponent<Image>();

            if (item != null)
            {
                itemIcon.sprite = item.itemIcon;
            }
        }
    }

    public void StartBattle()
    {
        foreach (Item item in characterInventory)
        {
            if (item.itemType == Item.ItemType.Weapon)
            {
                // Karakter silah taşıyorsa
                Weapon weapon = item as Weapon;
                if (elenaCharacter != null)
                {
                    elenaCharacter.TakeDamage(weapon.damage);
                }
                if (warriorCharacter != null)
                {
                    warriorCharacter.TakeDamage(weapon.damage);
                }
            }
            else if (item.itemType == Item.ItemType.Potion)
            {
                // Karakter iksir taşıyorsa
                Potion potion = item as Potion;
                if (elenaCharacter != null)
                {
                    elenaCharacter.Heal(potion.healingAmount);
                }
                if (warriorCharacter != null)
                {
                    warriorCharacter.Heal(potion.healingAmount);
                }
            }
        }
    }
    */
