using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    const int MAX_NBR_ITEMS_PER_LINE = 6;
    const int OFFSET_BETWEEN_ITEMS = 25;

    [SerializeField] private GameObject _itemUiPrefab;
    [SerializeField] private ItemUI _selectedItem;
    public ItemUI SelectedItem
    {
        get { return _selectedItem; }
    }

    [SerializeField] private GameObject _contextualMenuPrefab;
    [SerializeField] private GameObject _itemListHolderPrefab;
    [SerializeField] private Transform _itemPages;

    List<List<GameObject>> _itemsUiObjects = new List<List<GameObject>>();
    List<GameObject> _itemsHolders = new List<GameObject>();

    private Inventory _inventory;
    public int Money
    {
        get { return _inventory.Money; }
    }

    private Inventory.ItemCategoryList _activeCategory;
    public Inventory.ItemCategoryList ActiveCategory
    {
        get { return _activeCategory; }
    }

    private int _activeCategoryIdx;

    void Start()
    {
        _inventory = FindObjectOfType<Inventory>();

        if (_inventory)
        {
            if (_itemListHolderPrefab && _itemPages)
            {
                Vector2 nexItemPos = new Vector2(0, 0);
                for (int i = 0; i < _inventory.ItemsByCategory.Count; i++)
                {
                    nexItemPos = new Vector2(-_itemListHolderPrefab.GetComponent<RectTransform>().rect.width / 2f,
                        _itemListHolderPrefab.GetComponent<RectTransform>().rect.height / 2f);

                    GameObject listHolder = Instantiate(_itemListHolderPrefab, _itemPages);
                    listHolder.SetActive(false);
                    _itemsHolders.Add(listHolder);
                    
                    if (i == 0)
                    {
                        listHolder.SetActive(true);
                    }
                    _itemsUiObjects.Add(new List<GameObject>());
                    int maxSlots = _inventory.GetMaxInventorySlots(i);
                    for (int j = 0; j < maxSlots; j++)
                    {
                        AddItemSlot(ref nexItemPos, listHolder.GetComponent<RectTransform>(), i);
                    }

                    GameObject contextualMenu = Instantiate(_contextualMenuPrefab, listHolder.transform);
                    contextualMenu.GetComponent<ContextualMenu>().InventoryUi = this;

                    for (int j = 0; j < maxSlots; j++)
                    {
                        _itemsUiObjects[i][j].GetComponent<ItemButton>().ContextualMenu = contextualMenu;
                    }
                }
            }

            _activeCategory = _inventory.ItemsByCategory[0];
            _activeCategoryIdx = 0;
        }
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null || !_selectedItem.gameObject.activeInHierarchy)
        {
            _selectedItem.MyItem = null;
        }
    }

    public void AddItemSlot(ref Vector2 nexItemPos, RectTransform itemListHolder, int itmIdx)
    {
        GameObject itmUi = Instantiate(_itemUiPrefab, itemListHolder.transform);
        itmUi.GetComponent<RectTransform>().anchoredPosition = nexItemPos;

        itmUi.GetComponent<ItemButton>().InventoryUi = this;

        nexItemPos.x += _itemUiPrefab.GetComponent<RectTransform>().rect.width + OFFSET_BETWEEN_ITEMS;
        if (nexItemPos.x + _itemUiPrefab.GetComponent<RectTransform>().rect.width > 
            itemListHolder.localPosition.x + itemListHolder.rect.width / 2f)
        {
            nexItemPos.x = -itemListHolder.rect.width / 2f;
            nexItemPos.y -= _itemUiPrefab.GetComponent<RectTransform>().rect.height + OFFSET_BETWEEN_ITEMS;
        }
        itmUi.SetActive(false);
        _itemsUiObjects[itmIdx].Add(itmUi);
    }


    public void UpdateListItem(Item.Type itemType)
    {
        int idx = (int)itemType;
        int maxSlots = _inventory.GetMaxInventorySlots(idx);
        for (int i = 0; i < maxSlots; i++)
        {
            if (i >= _inventory.ItemsByCategory[idx].Items.Count)
            {
                _itemsUiObjects[idx][i].GetComponent<ItemUI>().MyItem = null;
                _itemsUiObjects[idx][i].SetActive(false);
            }
            else
            {
                _itemsUiObjects[idx][i].GetComponent<ItemUI>().MyItem = _inventory.ItemsByCategory[idx].Items[i];
                _itemsUiObjects[idx][i].SetActive(true);
            }
        }
    }

    public void UnselectItem()
    {
        if (_selectedItem)
        {
            _selectedItem.MyItem = null;
        }
    }

    public void ChangeUIActiveCategory(bool changeUp)
    {
        _itemsHolders[_activeCategoryIdx].SetActive(false);
        if (changeUp)
        {
            _activeCategoryIdx++;
            if (_activeCategoryIdx == _inventory.ItemsByCategory.Count)
            {
                _activeCategoryIdx = 0;
            }
        }
        else
        {
            _activeCategoryIdx--;
            if (_activeCategoryIdx == -1)
            {
                _activeCategoryIdx = _inventory.ItemsByCategory.Count -1;
            }
        }

        _activeCategory = _inventory.ItemsByCategory[_activeCategoryIdx];
        _itemsHolders[_activeCategoryIdx].SetActive(true);
    }

    private void OnEnable()
    {
        if (_itemsUiObjects.Count > 0 && _itemsUiObjects[(int)_activeCategory.Type][0])
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_itemsUiObjects[(int)_activeCategory.Type][0]);
        }
        
    }
}
