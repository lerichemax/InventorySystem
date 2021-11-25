using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon
{
    [SerializeField] private float _bleedingDamage;
    [SerializeField] private float _bleedingTime;

    protected override void WeaponEffect()
    {
        Debug.Log(_name + " used and dealed " + _damage.ToString() + " damage. Applied bleeding effect that will deal "+
            _bleedingDamage.ToString() + " damage over " + _bleedingTime.ToString() + " seconds");
    }

    public override string GetDescription()
    {
        return _description + "\nDeals" + _damage.ToString() + " damage and " + _bleedingDamage.ToString() + "bleeding damage over "
            + _bleedingTime.ToString() + " seconds";
    }
}