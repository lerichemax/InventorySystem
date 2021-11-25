using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextualMenu : MonoBehaviour
{
    private InventoryUI _inventoryUI;
    public InventoryUI InventoryUi
    {
        get { return _inventoryUI; }
        set { _inventoryUI = value; }
    }

    private GameObject _currentParentBtnObject;
    public GameObject CurrentParentBtnObject
    {
        set { _currentParentBtnObject = value; }
    }

    GameObject _childBtn1;
    GameObject _childBtn2;

    private void Awake()
    {
        _childBtn1 = transform.Find("UseButton").gameObject;
        _childBtn2 = transform.Find("SellButton").gameObject;
    }


    private void Update()
    {
        GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
        if (currentSelected == null || 
            (currentSelected != _currentParentBtnObject && currentSelected != _childBtn1 && currentSelected != _childBtn2) ||
            _currentParentBtnObject.activeInHierarchy == false ||
            _inventoryUI.SelectedItem.MyItem == null)
        {
            gameObject.SetActive(false);
        }
    }
}
