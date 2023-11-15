using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory 
{
    
    // List to store the character's items
    public List<Item> items = new List<Item>();

    // Add an item to the inventory
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    // Remove an item from the inventory
    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    // Get a list of items in the inventory
    public List<Item> GetItems()
    {
        return items;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
