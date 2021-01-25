using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
    public GameObject player;
    private Touch touch;
    float x, y, z;
    public float speed;
    private Rigidbody rb;
    public GameObject pauseMenu;
    
    [SerializeField]
    private Transform _player;
    private Vector3 directionToFace;
    
    Vector3 spawnpos = new Vector3(4, 0.05f, 0.5f);
    Vector3 plspawnpos = new Vector3(1.5f, 0.2f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {


        if (_player == null)
        {
            directionToFace = transform.forward;
        }
        else
        {

            directionToFace = _player.position - transform.position - new Vector3(0, 0.15f, 0);
        }

        transform.rotation = Quaternion.LookRotation(directionToFace);
        if (pauseMenu.active == false)
        {
            if (rb.velocity == Vector3.zero)
            {
                if (Input.touchCount > 0 && _player != null)
                {
                    touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Ended)
                    {

                        rb.velocity = new Vector3(
                            x = (directionToFace.x - transform.position.x) * speed * Time.deltaTime,
                            y = 0.0f,
                            z = directionToFace.z * speed * Time.deltaTime);
                    }


                }
            }
        }




    }


    


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TopWall" || other.gameObject.name == "BottomWall")
        {
            rb.velocity = new Vector3(x = -x * speed * Time.deltaTime, y, z);
            
        }else if(other.gameObject.name == "Block" || other.gameObject.name == "Block1" || other.gameObject.name == "Block2")
        {
            other.gameObject.SetActive(false);
            DesAndSpawn();
            
            
        }else if (other.gameObject.name == "RightWall" || other.gameObject.name == "LeftWall")
        {
            rb.velocity = new Vector3(x , y, z = -z * speed * Time.deltaTime);
            
        }else if (other.gameObject.name == "Enemy")
        {
            DesAndSpawn();
        }
    }

    void DesAndSpawn()
    {
        
            gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
            gameObject.transform.position = spawnpos;
            player.transform.position = plspawnpos;
            gameObject.SetActive(true);
            player.SetActive(true);
        
    }
        
}
