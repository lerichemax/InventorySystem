using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(InventorySettings))]
public class Inventory : Observer
{ 
    private List<ItemCategoryList> _itemsByCategory = new List<ItemCategoryList>();
    public List<ItemCategoryList> ItemsByCategory
    {
        get { return _itemsByCategory; }
    }

    private InventoryUI _inventoryUi;
    private InventorySettings _inventorySettings;

    private int _money;
    public int Money
    {
        get { return _money; } 
    }

    private void Awake()
    {
        _inventoryUi = FindObjectOfType<InventoryUI>();
        _inventorySettings = GetComponent<InventorySettings>();
        for (int i = 0; i < Enum.GetValues(typeof(Item.Type)).Length; i++)
        {
            _itemsByCategory.Add(new ItemCategoryList((Item.Type)i));
        }
    }

    public void AddItem(Item item)
    {
        Item newItem = Instantiate(item, transform);

        int idx = FindFirstAvailableSlotIndexByName(_itemsByCategory[(int)newItem.ItemType].Items, newItem.Name);

        int maxInventorySlot;
        int maxStackable = newItem.MaxAmount;
        InventorySettings.CategorySettings settings = new InventorySettings.CategorySettings();
        if (_inventorySettings.GetSettings(newItem.ItemType, ref settings))
        {
            maxInventorySlot = settings.MaxInventorySlots;
        }
        else
        {
            maxInventorySlot = _inventorySettings.DefaultMaxInventorySlot;
        }

        if (idx != -1)
        {
            if (_itemsByCategory[(int)newItem.ItemType].Items.Count == maxInventorySlot - 1 && 
                _itemsByCategory[(int)newItem.ItemType].Items[idx].Amount >= maxStackable)
            {
                Debug.Log("No space in inventory for this item");
                Destroy(newItem.gameObject);
                return;
            }

            _itemsByCategory[(int)newItem.ItemType].Items[idx].Amount++;
            Destroy(newItem.gameObject);
        }
        else if(_itemsByCategory[(int)newItem.ItemType].Items.Count != maxInventorySlot)
        {
            _itemsByCategory[(int)newItem.ItemType].Items.Add(newItem);
            newItem.Amount = 1;
            newItem.AddObserver(this);
            _inventoryUi.UpdateListItem(newItem.ItemType);
            newItem.gameObject.SetActive(false);
        }
        else
        {
            Destroy(newItem.gameObject);
            Debug.Log("Item not added -> no space in inventory");
        }
    }

    int FindFirstAvailableSlotIndexByName(List<Item> collection, string name)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].Name == name && collection[i].Amount < collection[i].MaxAmount)
            {
                return i;
            }
        }
        return -1;
    }

    public override void OnNotify(object obj, ObserverEvent obsEvent)
    {
        Item itm = (Item)obj;
        switch (obsEvent)
        {
            case ObserverEvent.ItemDestroyed:
                if (itm && itm.Amount == 0)
                {
                    _itemsByCategory[(int)itm.ItemType].Items.Remove(itm);
                    Destroy(itm.gameObject);
                    _inventoryUi.UpdateListItem(itm.ItemType);
                }
                break;
            case ObserverEvent.ItemSold:
                _money += itm.SellValue;   
                break;
            default:
                break;
        }
    }

    public int GetMaxInventorySlots(int categoryIdx)
    {
        if (categoryIdx < 0 || categoryIdx >= _itemsByCategory.Count)
        {
            return 0;
        }
        InventorySettings.CategorySettings settings = new InventorySettings.CategorySettings();
        if (_inventorySettings.GetSettings(_itemsByCategory[categoryIdx].Type, ref settings) && settings.MaxInventorySlots != 0)
        {
            return settings.MaxInventorySlots;
        }
        return _inventorySettings.DefaultMaxInventorySlot;
    }

    public struct ItemCategoryList
    {
        public Item.Type Type;
        public List<Item> Items;

        public ItemCategoryList(Item.Type type)
        {
            Type = type;
            Items = new List<Item>();
        }
    }
}
