using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item
{
    public int damage;
    public int strength;
    
    public WeaponItem(string name, Sprite icon, int damage) : base(name, icon, ItemType.Weapon)
    {
        this.damage = damage;
    }

    public override void UseItem(Character character)
    {
        throw new System.NotImplementedException();
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


