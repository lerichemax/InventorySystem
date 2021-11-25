using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic : Item
{
    [SerializeField] protected float _magicalDamage;

    void Awake()
    {
        _itemType = Type.Magic;
    }

    public override void UseItem()
    {
        MagicalInvocation();
        RemoveAnItem();
    }

    protected abstract void MagicalInvocation();
}
