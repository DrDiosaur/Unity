using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] private Sprite icon;

    [SerializeField]
    private int price;
    public Sprite Icon => icon;

    private SlotScript slot;

    protected SlotScript Slot
    {
        get => slot;
        set => slot = value;
    }

    public int Price => price;
}
