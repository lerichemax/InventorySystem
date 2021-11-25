using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TestItemAdder))]
[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    [SerializeField] private InventoryUI _inventoryUI;
    private Inventory _inventory;
    private TestItemAdder _itemAdder;
    bool _isInventoryActive;

    void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _itemAdder = GetComponent<TestItemAdder>();
    }

    private void Start()
    {
        if (_inventoryUI && _inventoryUI.gameObject.activeInHierarchy)
        {
            _inventoryUI.gameObject.SetActive(false);
        }
        _inventory.InventoryUi = _inventoryUI;
    }

    void Update()
    {
        if(Input.GetButtonUp("ShowInventory") && _inventoryUI)
        {
            if (_isInventoryActive)
            {
                _inventoryUI.gameObject.SetActive(false);
            }
            else
            {
                _inventoryUI.gameObject.SetActive(true);
            }
            _isInventoryActive = !_isInventoryActive;
        }
        else if (Input.GetButtonUp("AddMelee"))
        {
            _inventory.AddItem(_itemAdder.SpawnAMeleeWeapon());
        }
        else if(Input.GetButtonUp("AddRanged"))
        {
            _inventory.AddItem(_itemAdder.SpawnARangedWeapon());
        }
        else if (Input.GetButtonUp("AddConsumable"))
        {
            _inventory.AddItem(_itemAdder.SpawnAConsumable());
        }
        else if (Input.GetButtonUp("AddObject"))
        {
            _inventory.AddItem(_itemAdder.SpawnAnObject());
        }
        else if (Input.GetButtonUp("AddMagic"))
        {
            _inventory.AddItem(_itemAdder.SpawnMagic());
        }
    }
}
