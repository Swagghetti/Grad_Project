using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Items/Potion")]
public class Potion : Item
{
    public int healingAmount;

     public Potion(string name, int healingAmount, Sprite icon) : base(name, icon, ItemType.Potion)
    {
        this.healingAmount = healingAmount;
        this.itemType = ItemType.Potion;
    }


    public override void UseItem(Character character)
    {
        character.Heal(healingAmount);
    }
}

