using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public abstract class UIButton : MonoBehaviour
{
    private Button _btn;
    protected virtual void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(ButtonAction);
    }

    protected abstract void ButtonAction();

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!EventSystem.current.alreadySelecting)
            EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        this.GetComponent<Selectable>().OnPointerExit(null);
    }
}
