using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventorySettings : MonoBehaviour
{
    private int _defaultMaxInventorySlot = 10;
    public int DefaultMaxInventorySlot
    {
        get { return _defaultMaxInventorySlot; }
    }

    [SerializeField] private List<CategorySettings> _categorySettings = new List<CategorySettings>();
    public List<CategorySettings> CategorySettingsList
    {
        get { return _categorySettings; }
    }

    private void OnValidate()
    {
        if (_categorySettings.Count != Enum.GetValues(typeof(Item.Type)).Length)
        {
            FillDefaultList();
        }
    }

    public bool GetSettings(Item.Type type, ref CategorySettings settings)
    {
        for (int i = 0; i < _categorySettings.Count; i++)
        {
            if (_categorySettings[i].ItemType == type)
            {
                settings = _categorySettings[i];
                return true;
            }
        }
        return false;
    }

    public void FillDefaultList()
    {
        _categorySettings.Clear();
        for (int i = 0; i < Enum.GetValues(typeof(Item.Type)).Length; i++)
        {
            _categorySettings.Add(new CategorySettings((Item.Type)i));
        }
    }

    [Serializable]
    public struct CategorySettings
    {
        [ReadOnly] [SerializeField] private Item.Type _itemType;
        public Item.Type ItemType
        {
            get { return _itemType; }
        }

        [Range(0, 25)] public int MaxInventorySlots; // remove range when scrolling will be implemented

        public CategorySettings(Item.Type type)
        {
            _itemType = type;
            MaxInventorySlots = 0;
        }
    }
}
