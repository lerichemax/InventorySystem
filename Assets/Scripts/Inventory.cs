using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : Observer
{
    [SerializeField] private int _maxInventorySlot = 10;
    [SerializeField] private int _maxStackableItem = 5;

    public int MaxInventorySlot
    {
        get { return _maxInventorySlot; }
    }

    private List<ItemCategoryList> _itemsByCategory = new List<ItemCategoryList>();
    public List<ItemCategoryList> ItemsByCategory
    {
        get { return _itemsByCategory; }
    }

    private InventoryUI _inventoryUi;
    public InventoryUI InventoryUi
    {
        set { _inventoryUi = value; }
    }

    private int _money;
    public int Money
    {
        get { return _money; } 
    }

    private void Awake()
    {
        for (int i = 0; i < Enum.GetValues(typeof(Item.Type)).Length; i++)
        {
            _itemsByCategory.Add(new ItemCategoryList((Item.Type)i));
        }
    }

    public void AddItem(Item item)
    {
        Item newItem = Instantiate(item, transform);

        int idx = FindFirstAvailableSlotIndexByName(_itemsByCategory[(int)newItem.ItemType].Items, newItem.Name);

        if (idx != -1)
        {
            if (_itemsByCategory[(int)newItem.ItemType].Items.Count == _maxInventorySlot - 1 && 
                _itemsByCategory[(int)newItem.ItemType].Items[idx].Amount >= _maxStackableItem)
            {
                Debug.Log("No space in inventory for this item");
                Destroy(newItem.gameObject);
                return;
            }

            _itemsByCategory[(int)newItem.ItemType].Items[idx].Amount++;
            Destroy(newItem.gameObject);
        }
        else if(_itemsByCategory[(int)newItem.ItemType].Items.Count != MaxInventorySlot)
        {
            _itemsByCategory[(int)newItem.ItemType].Items.Add(newItem);
            newItem.Amount = 1;
            newItem.AddObserver(this);
            _inventoryUi.UpdateListItem(newItem.ItemType);
            newItem.gameObject.SetActive(false);
        }
    }

    int FindFirstAvailableSlotIndexByName(List<Item> collection, string name)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].Name == name && collection[i].Amount < _maxStackableItem)
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
