using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : UIButton
{
    [SerializeField] private ContextualMenu _menu;

    private Text _sellText;

    protected override void Awake()
    {
        base.Awake();
        _sellText = transform.Find("Sell").GetComponent<Text>();
    }

    private void Update()
    {
        if (_menu && _sellText)
        {
            _sellText.text = "Sell (" + _menu.InventoryUi.SelectedItem.MyItem.SellValue.ToString() + ")";
        }
    }

    protected override void ButtonAction()
    {
        if (_menu)
        {
            _menu.InventoryUi.SelectedItem.MyItem.Sell();
        }
    }
}
