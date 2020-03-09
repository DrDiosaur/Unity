using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Random = UnityEngine.Random;

public class Ball_Movement : MonoBehaviour
{
    float x, y, z;
    public float speed = 2f;
    public float accel = 1.03f;
    private Rigidbody rb;
    private bool q = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        
    }
    


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            if (q.Equals(true))
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.velocity = new Vector3(x = Random.Range(-5.0f, 5.0f) * speed * Time.deltaTime, y = 0.0f,
                z = Random.Range(-10.0f, 10.0f) * speed * Time.deltaTime);
                q = false;
            }
        }


        if (transform.position.z < -29  || transform.position.z > 31){
            transform.position = new Vector3(x = 0.0f, y = 0.05f, z = 0.0f);
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            q = true;
            

        }
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Side Wall" || other.gameObject.name == "Side Wall2")
        {
            rb.velocity = new Vector3(x = -x * accel, y, z * accel);
            
        }else if (other.gameObject.name == "Wall" || other.gameObject.name == "Wall2" || other.gameObject.name == "Wall3" || other.gameObject.name == "Wall4" || other.gameObject.name == "Player1" || other.gameObject.name == "Player2" )
        {
            rb.velocity = new Vector3(x * accel, y, z = -z * accel);
        }
    }
    
    
    
}

