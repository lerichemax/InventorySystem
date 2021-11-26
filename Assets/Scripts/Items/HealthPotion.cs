using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Consumable
{
    [Space]
    [SerializeField] private float _healthToRestore;

    protected override void Consume()
    {
        Debug.Log("Health porion drunk and restored " + _healthToRestore.ToString());
    }

    public override string GetDescription()
    {
        return _description + "\nRestores " + _healthToRestore.ToString() + " health";
    }
}
