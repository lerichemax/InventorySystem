using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategorySwitcher : MonoBehaviour
{
    private InventoryUI _inventoryUi;

    [SerializeField] private Text _categoryText;

    void Awake()
    {
        _inventoryUi = FindObjectOfType<InventoryUI>();

        transform.Find("BtnLeft").GetComponent<SwitchCategoryButton>().CategorySwitcher = this;
        transform.Find("BtnRight").GetComponent<SwitchCategoryButton>().CategorySwitcher = this;
    }

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        _categoryText.text = _inventoryUi.ActiveCategory.Type.ToString();
    }
}
