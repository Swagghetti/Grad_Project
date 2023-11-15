using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemIconPrefab; // Reference to the item icon prefab
    public Transform itemIconContainer; // The parent object for item icons in the UI

    private CharacterInventory characterInventory;

    // Start is called before the first frame update
    void Start()
    {
        characterInventory = GetComponent<CharacterInventory>(); // Reference to the character's inventory

        // Loop through the items in the character's inventory
        foreach (Item item in characterInventory.items)
        {
            // Instantiate an item icon from the prefab
            GameObject itemIcon = Instantiate(itemIconPrefab, itemIconContainer);

            // Set the item icon's image (assuming you have a method to retrieve the item's image)
            Image itemImage = itemIcon.GetComponent<Image>();
            itemImage.sprite = item.GetIcon();

            // You can also set other item information (e.g., item name or quantity) on the item icon here
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
