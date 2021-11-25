using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : Subject
{
    public enum Type
    {
        Melee,
        Range,
        Consumable,
        Object,
        Magic
    }

    protected Type _itemType;
    public Type ItemType
    {
        get { return _itemType; }
    }

    [SerializeField] protected string _name;
    public string Name
    {
        get { return _name; }
    }
    [SerializeField] protected string _description;

    [SerializeField] protected Texture2D _image;
    public Texture2D Image
    {
        get { return _image; }
    }

    [SerializeField] private int _sellValue;
    public int SellValue
    { 
        get { return _sellValue; }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public abstract void UseItem();

    protected void RemoveAnItem()
    {
        _amount--;
        if (_amount == 0)
        {
            Notify(this, ObserverEvent.ItemDestroyed);
        }
    }

    public abstract string GetDescription();

    public void Sell()
    {
        Notify(this, ObserverEvent.ItemSold);
        RemoveAnItem();
    }
}