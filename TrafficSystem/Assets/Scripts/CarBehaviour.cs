using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarBehaviour : MonoBehaviour
{

  public bool isStopped;

    public GameObject TraversedObject;
   
    public int DirectionOfTravel; 
    //1 = up
    //2 = right
    //3 = down
    //4 = right
    

    // Update is called once per frame
    void Update()
    {
        
        RaycastDetect();
        TravelDirection(); 
        if (!isStopped)
        {
            transform.Translate(Vector3.forward / 50);
        }
    }

    private void TravelDirection()
    {
        if (transform.rotation.y == 0)
        {
            DirectionOfTravel = 1;
        }
        else if (transform.rotation.y == 90 || transform.rotation.y == -270)
        {
            DirectionOfTravel = 2;
        }
        else if (transform.rotation.y == 180 || transform.rotation.y == -180)
        {
            DirectionOfTravel = 3;
        }
        else if (transform.rotation.y == 270 || transform.rotation.y == -90)
        {
            DirectionOfTravel = 4;
        }
    }
    private void RaycastDetect()
    {
        if (Physics.Raycast(transform.position, Vector3.up, out RaycastHit hit))
        {
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponentInChildren<TrafficLightChange>() != null)
                {
                    CheckLights(hit);
                }
                else if(hit.collider.gameObject.GetComponentInChildren<Intersect>() != null)
                {
                    CheckIntersect(hit);
                }
            }
        }
    }
    private void CheckLights(RaycastHit HitObject)
    {
        if (HitObject.collider.gameObject.GetComponentInChildren<TrafficLightChange>().state == 1)
        {
            //red light
            //stop
            isStopped = true;
        }
        else if (HitObject.collider.gameObject.GetComponentInChildren<TrafficLightChange>().state == 2)
        {
            //yellow light
            //slow to stop
            isStopped = true;
        }
        else if (HitObject.collider.gameObject.GetComponentInChildren<TrafficLightChange>().state == 3)
        {
            //green light
            //keep going or start going if stopped
            if (isStopped == true)
            {
                isStopped = false;
            }
        }
    }
    private void CheckIntersect(RaycastHit HitObject)
    {
        if(HitObject.collider.gameObject != TraversedObject)
        {
            //if the road is a x turn
            if (HitObject.collider.gameObject.GetComponentInChildren<Intersect>().state == 3)
            {
                int i = Random.Range(0, 4);;
                
                    if (0 <= i && i < 1)
                    {
                        transform.Rotate(new Vector3(0, 180, 0)); 
                        transform.Translate(0.5f, 0.0f, 0.0f);
                    }else if (1 <= i && i < 2)
                    {
                        transform.Rotate(new Vector3(0, 0, 0));
                    }else if (2 <= i && i < 3)
                    {
                        transform.Rotate(new Vector3(0, 90, 0));
                    }else if (3 <= i && i < 4)
                    {
                        transform.Rotate(new Vector3(0, -90, 0));
                        transform.Translate(0.5f, 0, 0);
                    }

                    
                
               
                transform.Translate(0, 0, 0);
                TraversedObject = HitObject.collider.gameObject;
            }
            //if the road is an L shaped turn
            else if (HitObject.collider.gameObject.GetComponentInChildren<Intersect>().state == 1)
            {

                if (HitObject.collider.gameObject.GetComponentInChildren<Ways>().ReturnRight())
                {

                    transform.Rotate(new Vector3(0, 90, 0));
                    transform.Translate(0, 0, 0);
                    TraversedObject = HitObject.collider.gameObject;

                }
                else if (HitObject.collider.gameObject.GetComponentInChildren<Ways>().ReturnLeft())
                {

                    //turn left
                    transform.Rotate(new Vector3(0, -90, 0));
                    transform.Translate(0, 0, 0);
                    TraversedObject = HitObject.collider.gameObject;

                }
            }else if (HitObject.collider.gameObject.GetComponentInChildren<Intersect>().state == 2)
            {
                    //T turn
                    int j = Random.Range(0, 1);
                    if (HitObject.collider.gameObject.GetComponentInChildren<Ways>().ReturnLeft())
                    {
                        if (0 <= j && j < 1)
                        {
                            transform.Rotate(new Vector3(0, 0, 0));
                            
                        }
                        else if (1 <= j && j < 2)
                        {
                            transform.Rotate(new Vector3(0, -90, 0));
                            
                        }
                        transform.Translate(0.0f, 0.0f, 0.0f);
                        TraversedObject = HitObject.collider.gameObject;
                    }else if (HitObject.collider.gameObject.GetComponentInChildren<Ways>().ReturnUp())
                    {
                        if (0 <= j && j < 1)
                        {
                            transform.Rotate(new Vector3(0, 90, 0));
                            transform.Translate(-0.2f, 0.0f, 0.0f);
                        }
                        else if (1 <= j && j < 2)
                        {
                            transform.Rotate(new Vector3(0, -90, 0));
                            transform.Translate(0.5f, 0, 0);
                        }

                        TraversedObject = HitObject.collider.gameObject;
                    }else if (HitObject.collider.gameObject.GetComponentInChildren<Ways>().ReturnRight())
                    {
                        if (0 <= j && j < 1)
                        {
                            transform.Rotate(new Vector3(0, 0, 0));

                        }
                        else if (1 <= j && j < 2)
                        {
                            transform.Rotate(new Vector3(0, 90, 0));

                        }

                        transform.Translate(0.0f, 0.0f, 0.0f);
                        TraversedObject = HitObject.collider.gameObject;
                    }
                    
            }
            

        }
    }
}
