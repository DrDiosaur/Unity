using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{

   private Item _item;

   public bool IsEmpty = true;
   
   [SerializeField]
   private Image icon;

   public bool AddItem(Item item)
   {
      icon.sprite = item.Icon;
      icon.color = Color.white;
      this.IsEmpty = false;
      return true;
   }
}
