using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : Consumable
{
    [SerializeField] private float _manaToRestore;

    protected override void Consume()
    {
        Debug.Log("Mana porion drunk and restored " + _manaToRestore.ToString());
    }

    public override string GetDescription()
    {
        return _description + "\nRestores " + _manaToRestore.ToString() + " mana";
    }
}
