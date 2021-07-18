using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopKeeperButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private Text title;
    [SerializeField] private Text price;
    [SerializeField] private Text quantity;

    private List<SlotScript> slots = new List<SlotScript>();

    private void Awake()
    {
        slots.Add(FindObjectOfType<SlotScript>());
    }

    private ShopKeeperItem _shopKeeperItem;
    public void AddItem(ShopKeeperItem shopKeeperItem)
    {
        this._shopKeeperItem = shopKeeperItem;
        
        if (shopKeeperItem.Quantity > 0 || (shopKeeperItem.Quantity == 0 && shopKeeperItem.Unlimited))
        {
            icon.sprite = shopKeeperItem.Item.Icon;
            title.text = shopKeeperItem.Item.name;
            price.text = "Price: " + shopKeeperItem.Item.Price.ToString();

            if (!shopKeeperItem.Unlimited)
            {
                quantity.text = shopKeeperItem.Quantity.ToString();
            }

            if (shopKeeperItem.Item.Price > 0)
            {
                price.text = "Price: " + shopKeeperItem.Item.Price.ToString();
            }
            else
            {
                price.text = string.Empty;
            }
            gameObject.SetActive(true);
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerMovement.Instance.Gold >= _shopKeeperItem.Item.Price && BagScript.MyInstance.AddItem(_shopKeeperItem.Item))
        {
            SellItem();
            
            
        }
    }

    private void SellItem()
    {
        PlayerMovement.Instance.Gold -= _shopKeeperItem.Item.Price;

        if (!_shopKeeperItem.Unlimited)
        {
            _shopKeeperItem.Quantity--;
            quantity.text = _shopKeeperItem.Quantity.ToString();

            if (_shopKeeperItem.Quantity == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
