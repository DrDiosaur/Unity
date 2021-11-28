using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] public GameObject arrow;
    [SerializeField] public GameObject ball;
    
    
    private float velocityConstant = 10;

    private float leftLimit = -5.15f;

    private float rightLimit = 2.15f;

    private float topLimit = -17.5f;
    private float bottomLimit = -22.5f;

    private Vector3 startPos;

    private BallController ballControl;
    
    private void Awake()
    {
        ballControl = ball.GetComponent<BallController>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseControl.gameIsPaused == false)
        {

            if (Input.touchCount == 1) 
            {
                arrow.SetActive(true);
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.Translate(touch.deltaPosition.x / Screen.width * velocityConstant, 0.0f,
                        touch.deltaPosition.y / Screen.height * velocityConstant);
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                        transform.position.y, Mathf.Clamp(transform.position.z, bottomLimit, topLimit));

                    
                    arrow.transform.localScale =
                        new Vector2(((transform.position.z - startPos.z)),
                            arrow.transform.localScale.y);
                    ball.transform.LookAt(transform.position);

                }else if (touch.phase == TouchPhase.Ended)
                {
                    ballControl.LaunchBall();
                    gameObject.SetActive(false);
                    arrow.SetActive(false);
                    if (!BallController.ballIsLaunched)
                    {
                        transform.position = startPos;
                    }
                }

                
            }
        }
    }
}
