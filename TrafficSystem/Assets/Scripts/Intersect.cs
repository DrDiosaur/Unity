using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersect : MonoBehaviour
{
    
    public bool LTurn;//state 1
    public bool TTurn;//state 2
    public bool XTurn;//state 3

    public int state;

    // Update is called once per frame
    void Update()
    {
        if (LTurn)
        {
            state = 1;
        }
        else if (TTurn)
        {
            state = 2;
        }
        else if (XTurn)
        {
            state = 3;
        }
        
    }
}
