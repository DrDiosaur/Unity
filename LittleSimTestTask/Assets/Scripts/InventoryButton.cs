using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private InventoryScript _inventoryScript;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_inventoryScript.gameObject.active == true)
        {
            _inventoryScript.gameObject.SetActive(false); 
        }
        else
        {
            _inventoryScript.gameObject.SetActive(true); 
        }
       
    }
}
