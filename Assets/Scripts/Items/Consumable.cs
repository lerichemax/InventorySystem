using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : Item
{
    // Start is called before the first frame update
    void Awake()
    {
        _itemType = Type.Consumable;
    }

    public override void UseItem()
    {
        Consume();
        RemoveAnItem();
    }

    protected abstract void Consume();
}
