using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ShopKeeperItem[] _items;
    
    [SerializeField] private ShopKeeperWindow _shopKeeperWindow;

    public void Interact()
    {
        _shopKeeperWindow.CreatePages(_items);
        _shopKeeperWindow.Open();
    }

    public void StopInteract()
    {
        _shopKeeperWindow.Close();
    }
}
