using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public int damage;
    public int durability;
    public Sprite weaponIcon;

     public Weapon(string name, int damage, int durability, Sprite icon) : base(name, icon, ItemType.Weapon)
    {
        this.damage = damage;
        this.durability = durability;
        this.weaponIcon = icon;
    }

    public override void UseItem(Character character)
    {
        character.TakeDamage(damage);
    }
}


