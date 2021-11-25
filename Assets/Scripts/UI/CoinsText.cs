using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CoinsText : MonoBehaviour
{
    private InventoryUI _inventoryUi;
    private Text _coinsTxt;

    void Awake()
    {
        _inventoryUi = FindObjectOfType<InventoryUI>();
        _coinsTxt = GetComponent<Text>();
    }


    void Update()
    {
        _coinsTxt.text = _inventoryUi.Money.ToString();
    }
}
