using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    public Sprite layer_red, layer_orange;
    

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = layer_red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = layer_orange;
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name){
            case "Play":
                Application.LoadLevel("Play");
                break;
            case "Rating":
                Application.OpenURL("http://google.com");
                break;
        }
    }

}
