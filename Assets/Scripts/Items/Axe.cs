using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MeleeWeapon
{
    protected override void WeaponEffect()
    {
        Debug.Log(_name + " used and dealed " + _damage.ToString() + " damage");
    }

    public override string GetDescription()
    {
        return _description + "\nDeals" + _damage.ToString() + " damage";
    }
}
