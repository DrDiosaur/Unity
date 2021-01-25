using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;

    public Transform generationPoint;

    public float distanceBetween;

    private float platformWidth;

    public float distanceMin;

    public float distanceMax;

    //public GameObject[] platforms;
    private int platformSelector;

    private float[] platformsWidth;

    public PlatformManager[] platformsM;

    private float minHeight;

    public Transform maxHeightPoint;

    private float maxHeight;

    public float maxHeightChange;

    private float heightChange;
    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        
        platformsWidth = new float[platformsM.Length];

        for (int i = 0; i < platformsM.Length; i++)
        {
            platformsWidth[i] = platformsM[i].platform.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceMin, distanceMax);
            
            platformSelector = Random.Range(0, platformsM.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeightChange)
            {
                heightChange = maxHeight;
            }else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            
            transform.position = new Vector3(transform.position.x + platformsWidth[platformSelector] + distanceBetween, heightChange, transform.position.z);

           

            //Instantiate(/*platform*/ platforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = platformsM[platformSelector].GetPlatform();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
}
