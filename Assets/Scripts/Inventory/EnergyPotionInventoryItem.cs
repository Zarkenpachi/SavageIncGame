﻿public class EnergyPotionInventoryItem : InventoryItem
{
    public override void LeftClick(Inventory inventory, CharacterBase character)
    {
        inventory.RemoveItem(Item);
        character.ReplenishEnergy(((EnergyPotionItem)Item).effectAmount);
    }

    public override void RightClick(Inventory inventory)
    {
    }
}