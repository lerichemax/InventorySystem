using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemUI))]
public class ItemButton : UIButton
{
    private InventoryUI _inventoryUi;
    public InventoryUI InventoryUi
    {
        set { _inventoryUi = value; }
    }

    private GameObject _contextualMenu;
    public GameObject ContextualMenu
    {
        set { _contextualMenu = value; }
    }

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void ButtonAction()
    {
        _inventoryUi.SelectedItem.MyItem = GetComponent<ItemUI>().MyItem;
        Vector2 pos = GetComponent<RectTransform>().localPosition;
        pos.x += GetComponent<RectTransform>().rect.width;

        _contextualMenu.GetComponent<RectTransform>().localPosition = pos;
        _contextualMenu.GetComponent<ContextualMenu>().CurrentParentBtnObject = gameObject;
        _contextualMenu.SetActive(true);
    }

    
}
