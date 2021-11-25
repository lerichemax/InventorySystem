using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsObject : Item
{
    void Awake()
    {
        _itemType = Type.Object;
    }

    public override string GetDescription()
    {
        return _description;
    }

    public override void UseItem()
    {
        Debug.Log(_name + "used");
        RemoveAnItem();
    }
}
