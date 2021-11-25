using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItemAdder : MonoBehaviour
{
    [SerializeField] private MeleeWeapon[] _meleeWeaponPrefabs;
    [SerializeField] private RangedWeapon[] _rangedWeaponPrefabs;
    [SerializeField] private Consumable[] _consumablePrefabs;
    [SerializeField] private UtilsObject[] _objectnPrefabs;
    [SerializeField] private Magic[] _magicPrefabs;

    public MeleeWeapon SpawnAMeleeWeapon()
    {
        int idx = Random.Range(0, _meleeWeaponPrefabs.Length);
        return _meleeWeaponPrefabs[idx];
    }

    public RangedWeapon SpawnARangedWeapon()
    {
        int idx = Random.Range(0, _rangedWeaponPrefabs.Length);
        return _rangedWeaponPrefabs[idx];
    }

    public Consumable SpawnAConsumable()
    {
        int idx = Random.Range(0, _consumablePrefabs.Length);
        return _consumablePrefabs[idx];
    }

    public UtilsObject SpawnAnObject()
    {
        int idx = Random.Range(0, _objectnPrefabs.Length);
        return _objectnPrefabs[idx];
    }

    public Magic SpawnMagic()
    {
        int idx = Random.Range(0, _magicPrefabs.Length);
        return _magicPrefabs[idx];
    }

}
