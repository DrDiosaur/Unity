using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopKeeperItem
{
    [SerializeField]
    private Item item;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private bool unlimited;

    public Item Item => item;

    public int Quantity
    {
        get => quantity;
        set => quantity = value;
    }

    public bool Unlimited => unlimited;
}
