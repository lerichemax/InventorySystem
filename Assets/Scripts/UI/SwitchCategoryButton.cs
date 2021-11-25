using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchCategoryButton : UIButton
{
    [SerializeField] private bool _switchUp;
    [SerializeField] private SwitchCategoryButton _otherBtn;

    private bool _isLocked;
    private bool _axisLocked;

    private InventoryUI _inventoryUi;
    private CategorySwitcher _categorySwitcher;
    public CategorySwitcher CategorySwitcher
    {
        set { _categorySwitcher = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        _inventoryUi = FindObjectOfType<InventoryUI>();
    }

    protected override void ButtonAction()
    {
        _inventoryUi.ChangeUIActiveCategory(_switchUp);
        _categorySwitcher.UpdateText();
    }

    private void Update()
    {
        float axisValue = Input.GetAxis("Horizontal");
        if (EventSystem.current.currentSelectedGameObject == gameObject && !_axisLocked && axisValue != 0 && !_isLocked)
        {
            Debug.Log(gameObject.name);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_otherBtn.gameObject);
            _axisLocked = true;
            _otherBtn._axisLocked = true;
            _otherBtn._isLocked = true;
        }
        if (axisValue == 0)
        {
            _axisLocked = false;
        }
        _isLocked = false;
    }

}
