using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Touch touch;
    public GameObject pauseMenu;
    private float SpeedModifier;
    // Start is called before the first frame update
    void Start()
    {
        SpeedModifier = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    if (transform.position.z > 1.90f)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y,
                            1.90f + touch.deltaPosition.x * SpeedModifier);
                    }
                    else if (transform.position.z < -0.95f)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y,
                            -0.95f + touch.deltaPosition.x * SpeedModifier);
                    }

                    if (transform.position.x < -1)
                    {
                        transform.position = new Vector3(-1 + touch.deltaPosition.y * -SpeedModifier,
                            transform.position.y, transform.position.z);
                    }

                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.y * -SpeedModifier,
                        transform.position.y,
                        transform.position.z + touch.deltaPosition.x * SpeedModifier);


                }
                else if (touch.phase == TouchPhase.Ended)
                {

                    gameObject.SetActive(false);

                }
            }
        
    }
}
