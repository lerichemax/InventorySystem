using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TestItemAdder))]
[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    private InventoryUI _inventoryUi;
    private Inventory _inventory;
    private TestItemAdder _itemAdder;
    private GameManager _gameManager;

    void Awake()
    {
        _inventoryUi = FindObjectOfType<InventoryUI>();
        _gameManager = FindObjectOfType<GameManager>();
        _inventory = GetComponent<Inventory>();
        _itemAdder = GetComponent<TestItemAdder>();
    }

    private void Start()
    {
        if (_inventoryUi && _inventoryUi.gameObject.activeInHierarchy)
        {
            _inventoryUi.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetButtonUp("ShowInventory") && _inventoryUi)
        {
            if (_gameManager.IsPaused)
            {
                _gameManager.SetPause(false);
                _inventoryUi.gameObject.SetActive(false);
            }
            else
            {
                _gameManager.SetPause(true);
                _inventoryUi.gameObject.SetActive(true);
            }
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
