using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour  
{
    int maxHealth = 100;
    int currentHealth;
    int strength = 10;
    //public int damage = 5;

    public Character(int maxHealth,  int currentHealth, int strength)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth; 
        this.strength = strength;
    }

    public Item currentItem; // The currently equipped item

    public CharacterInventory inventory = new CharacterInventory();

    // Example method to add an item to the character's inventory
    public void AddItemToInventory(Item item)
    {
        inventory.AddItem(item);
    }

    // Example method to remove an item from the character's inventory
    public void RemoveItemFromInventory(Item item)
    {
        inventory.RemoveItem(item);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;

        /*
        // Instantiate a weapon item
        WeaponItem weapon = new WeaponItem();
        weapon.name = "Sword";  //itemName
        weapon.damage = 10;
        weapon.itemIcon = Resources.Load<Sprite>("sword_icon"); // Load the icon from resources
        */

        // Load the weapon's icon sprite from the "Resources" folder
        Sprite weaponIcon = Resources.Load<Sprite>("sword_icon"); 

        // Instantiate a weapon item with the required arguments
        WeaponItem weapon = new WeaponItem("Sword", weaponIcon, 10);

        // Equip the weapon
        currentItem = weapon;

        // Use the current item
        currentItem.UseItem(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Implement game over logic or character death here
            Die();
        }
    }

    private void Die()
    {
        // Implement character death logic here
    }

    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;

        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }
    }

    public void Attack(Enemy enemy)
    {
        int damage = strength; // You can add more complex calculations
        enemy.TakeDamage(damage);
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
    }
}