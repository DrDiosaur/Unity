using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float speed = 1f;
    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        if (BallController.ballIsLaunched)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, transform.position.z), step);
        }
        else
        {
            transform.position = startPos;
        }
    }
}
