using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : Magic
{
    [SerializeField] private float _radius;

    protected override void MagicalInvocation()
    {
        Debug.Log("Spellbook read and invoked a spell that dealed " + _magicalDamage.ToString() + 
            " AOE damage in a radius of " + _radius.ToString());
    }

    public override string GetDescription()
    {
        return _description + "\nDeals " + _magicalDamage.ToString() + " magical damage in a radius of " + _radius.ToString();
    }
}
