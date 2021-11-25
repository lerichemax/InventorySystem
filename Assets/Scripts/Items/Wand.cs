using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Magic
{
    [SerializeField] private float _spellRange;

    protected override void MagicalInvocation()
    {
        Debug.Log("Weak spell casted and dealed " + _magicalDamage.ToString() + " damage to enemy at range " + _spellRange.ToString());
    }

    public override string GetDescription()
    {
        return _description + "\nDeals " + _magicalDamage.ToString() + " magical damage at " + _spellRange.ToString() 
            + " range";
    }
}
