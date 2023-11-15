using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour  //WeaponItem  //?
{
    public int damage = 20;
    //public float attackRate = 1f; // Attacks per second
    //private float nextAttackTime = 0f;

    public int strength = 50;

    public string itemName = "Sword";
    public Sprite itemIcon; 
    //public ItemType itemType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Attack(Character target)
    {
        /*
        if (Time.time >= nextAttackTime)
        {
            target.TakeDamage(damage);
            nextAttackTime = Time.time + 1f / attackRate;
        }
        */
    }

}

