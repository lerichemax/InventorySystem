using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Longbow : Bow
{
    [SerializeField] private float _stunTime;

    protected override void Shoot()
    {
        Debug.Log(_name + " used and dealed " + _rangedDamage.ToString() + " damage to enemy at range " + _range.ToString() +
            "and stunned him for " + _stunTime.ToString() + " seconds");
    }
}
