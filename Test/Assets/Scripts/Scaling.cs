using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
   
    [SerializeField]
    private Transform __player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float toScale =transform.position.z - __player.position.x;
        transform.localScale = new Vector3(1, 1, 2 + toScale);
    }
}
