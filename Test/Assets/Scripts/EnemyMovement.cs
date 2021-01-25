using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject ball;

    private Rigidbody rb;

    public float speed;

    private float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1 * Time.deltaTime);
        }

        if (transform.position.z > 1.92f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.92f * Time.deltaTime);
        }
        
        rb.velocity = new Vector3(x = 0.0f, y = 0.0f, z = (ball.transform.position.z - transform.position.z) * speed * Time.deltaTime);
        
        /*if (rb.velocity.z > 50)
        {
            z = 50;
        } else if (rb.velocity.z < -50)
        {
            z = -50;
        }
        else
        {
            z = 0;
        }*/
    }
}
