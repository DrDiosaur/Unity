using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Movement : MonoBehaviour
{    
    
    public float speed = 10.0f;
    private float horizontal;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0) {
            horizontal = Input.GetAxisRaw("Horizontal") * speed;

            if (transform.position.x < -12.5f)
            {
                transform.position = new Vector3(-12.5f, transform.position.y, transform.position.z);
            }

            if (transform.position.x > 14.5f)
            {
                transform.position = new Vector3(14.5f, transform.position.y, transform.position.z);
            }
        } else
        {
            horizontal = 0f;
        }
        
        rb.velocity = new Vector3(horizontal, 0, 0);
    }
    
}
