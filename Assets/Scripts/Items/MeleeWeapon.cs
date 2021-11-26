using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : Item
{
    [Space]
    [SerializeField] protected float _damage;

    void Awake()
    {
        _itemType = Item.Type.Melee;
    }

    public override void UseItem()
    {
        Debug.Log("weapon used");
        RemoveAnItem();
    }

    protected abstract void WeaponEffect();
}
