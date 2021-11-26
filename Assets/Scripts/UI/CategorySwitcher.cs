using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CategorySwitcher : MonoBehaviour
{
    private InventoryUI _inventoryUi;
    private SwitchCategoryButton _btnRight;

    [SerializeField] private Text _categoryText;


    void Awake()
    {
        _inventoryUi = FindObjectOfType<InventoryUI>();

        transform.Find("BtnLeft").GetComponent<SwitchCategoryButton>().CategorySwitcher = this;
        _btnRight = transform.Find("BtnRight").GetComponent<SwitchCategoryButton>();
        _btnRight.CategorySwitcher = this;
    }

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        _categoryText.text = _inventoryUi.ActiveCategory.Type.ToString();
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null || !EventSystem.current.currentSelectedGameObject.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(_btnRight.gameObject);
        }
    }
}
