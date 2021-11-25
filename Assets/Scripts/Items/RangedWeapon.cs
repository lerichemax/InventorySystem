using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Item
{
    [SerializeField] protected float _rangedDamage;
    [SerializeField] protected float _range;

    void Awake()
    {
        _itemType = Type.Range;
    }

    public override void UseItem()
    {
        Shoot();
        RemoveAnItem();
    }

    protected abstract void Shoot();
}
