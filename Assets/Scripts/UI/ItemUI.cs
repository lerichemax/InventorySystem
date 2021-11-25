using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private RawImage _img;
    [SerializeField] private Text _description;
    [SerializeField] private Text _amountTxt;

    private Item _item;
    public Item MyItem
    {
        get { return _item; }
        set { 
            _item = value;
            if (_item)
            {
                if(_name)
                {
                    _name.text = _item.Name;
                }
                
                if (_img)
                {
                    _img.texture = _item.Image;
                    _img.color = Color.white;
                }
                
                if (_description)
                {
                    _description.text = _item.GetDescription();
                }

                if (_amountTxt)
                {
                    _amountTxt.text = _item.Amount.ToString();
                }
            }
            else
            {
                if (_name)
                {
                    _name.text = "";
                }

                if (_img)
                {
                    _img.texture = null;
                    _img.color = new Color(0, 0, 0, 0);
                }

                if (_description)
                {
                    _description.text = "";
                }
                if (_amountTxt)
                {
                    _amountTxt.text = "";
                }
            }
        }
    }

    private void Update()
    {
        if (_item && _amountTxt)
        {
            _amountTxt.text = _item.Amount.ToString();
        }
    }

}
