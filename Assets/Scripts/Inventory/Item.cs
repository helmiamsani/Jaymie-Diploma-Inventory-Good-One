using UnityEngine;

public class Item
{
    #region Private Variables
    private int _id, _amount, _value;
    private ItemType _type;
    private string _name, _description;

    private Texture2D _icon;
    private GameObject _mesh;

    private int _damage, _armour, _heal;
    #endregion

    #region Public Properties
    public int ID
    {
        get { return _id; } //Read
        set { _id = value; } //Write
    }

    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public ItemType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public Texture2D Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    public GameObject MeshType
    {
        get { return _mesh; }
        set { _mesh = value; }
    }

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public int Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }

    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }
    #endregion
}

public enum ItemType
{
    Ingredient,
    Potion,
    Scroll,
    Food,
    Armour,
    Weapon,
    Craftable,
    Money,
    Quest,
    Misc,
    All
}
