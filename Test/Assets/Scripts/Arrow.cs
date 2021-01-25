using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    public GameObject player;
    public GameObject arrow;
    
    
    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0 && player.active == true)
        {
            Touch touch = Input.GetTouch(0);
            arrow.SetActive(true);
        }
        else
        {
            arrow.SetActive(false);
        }
    }
}
