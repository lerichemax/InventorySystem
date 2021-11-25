using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : RangedWeapon
{
    protected override void Shoot()
    {
        Debug.Log(_name + " used and dealed " + _rangedDamage.ToString() + " damage to enemy at range " + _range.ToString());
    }

    public override string GetDescription()
    {
        return _description + "\nDeals" + _rangedDamage.ToString() + " damage at a distance of " + _range.ToString();
    }
}
