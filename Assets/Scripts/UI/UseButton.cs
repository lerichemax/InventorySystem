using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : UIButton
{
    [SerializeField] private ContextualMenu _menu;


    protected override void ButtonAction()
    {
        if (_menu)
        {
            _menu.InventoryUi.SelectedItem.MyItem.UseItem();
            if (_menu.InventoryUi.SelectedItem.MyItem.Amount == 0)
            {
                _menu.InventoryUi.UnselectItem();
                _menu.gameObject.SetActive(false);
            }
        }
    }
}
