using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
        string _name = "";
        string _description = "";
        int _amount = 0;
        int _value = 0;
        ItemType _type = ItemType.Money;
        string _icon = "";
        string _mesh = "";
        int _damage = 0;
        int _armour = 0;
        int _heal = 0;

        switch (itemID)
        {
            case 0:
                _name = "Acorn";
                _description = "Good for eating.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Acorn";
                _mesh = "Ingredient/Acorn";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 1:
                _name = "Iceroom";
                _description = "Good for reheating body.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Iceroom";
                _mesh = "Ingredient/Iceroom";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 2:
                _name = "Bark";
                _description = "Good for burning.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Bark";
                _mesh = "Ingredient/Bark";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 3:
                _name = "Energizer";
                _description = "Drink it!! and you'll see what it does.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Potion;
                _icon = "Potion/Energizer";
                _mesh = "Potion/Energizer";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 4:
                _name = "Red Scroll";
                _description = "Usually can be achieved from Royal Family.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Scroll;
                _icon = "Scroll/Red Scroll";
                _mesh = "Scroll/Red Scroll";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 5:
                _name = "Traveller Torso";
                _description = "Popular among traveller.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Armour;
                _icon = "Armour/Traveller Torso";
                _mesh = "Armour/Traveller Torso";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 6:
                _name = "Hero Sword";
                _description = "Dragons can be sliced in a second.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Weapon;
                _icon = "Weapon/Hero Sword";
                _mesh = "Weapon/Hero Sword";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 7:
                _name = "Human Brain";
                _description = "First of all, Why do you have human brain?, Sell this brain to Town Macuni and get 200 Triangle of Gold.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Craftable;
                _icon = "Craftable/Human Brain";
                _mesh = "Craftable/Human Brain";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 8:
                _name = "State Bronze";
                _description = "The lowest currency in Boganga Nation.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Money;
                _icon = "Money/State Bronze";
                _mesh = "Money/State Bronze";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 9:
                _name = "Eye of Manousa";
                _description = "Manousa is a combination of horse, dragon, lion and tiger. Last time was seen around Dimitry Forest, all the Gejust lives there.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Quest;
                _icon = "Quest/Eye of Manousa";
                _mesh = "Quest/Eye of Manousa";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 10:
                _name = "Sheet";
                _description = "A flexible rest equipment. Can be used for sleeping and rest during travel.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Misc;
                _icon = "Misc/Sheet";
                _mesh = "Misc/Sheet";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;

            default:
                itemID = 0;
                _name = "Acorn";
                _description = "Good for eating.";
                _amount = 0;
                _value = 0;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Acorn";
                _mesh = "Ingredient/Acorn";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
        }

        Item temp = new Item
        {
            ID = itemID,
            Name = _name,
            Description = _description,
            Amount = _amount,
            Value = _value,
            Type = _type,
            Icon = Resources.Load("Icons/" + _icon) as Texture2D,
            Meshtype = Resources.Load("Mesh/" + _mesh) as GameObject,
            Damage = _damage,
            Armour = _armour,
            Heal = _heal
        };
        return temp;
    }
}
