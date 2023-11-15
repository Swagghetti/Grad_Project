using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
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

