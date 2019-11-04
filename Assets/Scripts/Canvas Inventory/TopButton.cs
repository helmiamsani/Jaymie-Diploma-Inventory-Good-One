using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopButton : MonoBehaviour
{
    public CanvasInventory inventory;
    public void All()
    {
        inventory.sortType = ItemType.All;
        Debug.Log("All");
    }

    public void Ingredient()
    {
        inventory.sortType = ItemType.Ingredient;
        Debug.Log("Ingredient");
    }

    public void Potion()
    {
        inventory.sortType = ItemType.Potion;
        Debug.Log("Potion");
    }

    public void Scroll()
    {
        inventory.sortType = ItemType.Scroll;
        Debug.Log("Scroll");
    }

    public void Food()
    {
        inventory.sortType = ItemType.Food;
        Debug.Log("Food");
    }

    public void Armour()
    {
        inventory.sortType = ItemType.Armour;
        Debug.Log("Armour");
    }

    public void Weapon()
    {
        inventory.sortType = ItemType.Weapon;
        Debug.Log("Weapon");
    }

    public void Craftable()
    {
        inventory.sortType = ItemType.Craftable;
        Debug.Log("Craftable");
    }

    public void Money()
    {
        inventory.sortType = ItemType.Money;
        Debug.Log("Money");
    }

    public void Quest()
    {
        inventory.sortType = ItemType.Quest;
        Debug.Log("Quest");
    }
}
