using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Controller : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody rb;
    public float speed = 10.0f;

    private float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -12.5f)
        {
            transform.position = new Vector3(-12.5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 14.5f)
        {
            transform.position = new Vector3(14.5f, transform.position.y, transform.position.z);
        }
       

        // if (ball.transform.position.x > transform.position.x){
        rb.velocity = new Vector3(x = (ball.transform.position.x - transform.position.x) * speed, y = 0.0f, z = 0.0f);
        if (rb.velocity.x > 50)
        {
            x = 50;
        } else if (rb.velocity.x < -50)
        {
            x = -50;
        }
        else
        {
            x = 0;
        }
        // }
        // if (ball.transform.position.x < transform.position.x)
        // {
        //     rb.velocity = new Vector3(x = transform.position.x - speed, y = 0.0f, z = 0.0f);
        // }
       
    }
   
}
