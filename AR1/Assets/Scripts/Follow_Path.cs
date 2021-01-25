using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Follow_Path : MonoBehaviour
{
    
    public Moving_Path MyPath;
    public Text buttonText;
    public Text timerText;
    public Score myscore;
    public AudioSource hit;
    
    public float speed = 1;

    public float maxDistance = .0001f;


    private bool gameRunning = false;

    private IEnumerator<Transform> pointInPath;

    // Start is called before the first frame update
    void Start()
    {
        if (MyPath == null)
        {
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonText.enabled == false || timerText.text == "0")
        {
            gameRunning = false;
        }

        if (gameRunning == true)
        {
            if (pointInPath == null || pointInPath.Current == null)
            {
                return;
            }

            transform.position =
                Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);

            var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
            if (distanceSquare < maxDistance * maxDistance)
            {
                pointInPath.MoveNext();
            }
        }
    }

    public void ButtonStart()
    {
        gameRunning = !gameRunning;
    }

    public void RestartButton()
    {
        gameRunning = false;

    }

    private void OnMouseDown()
    {
        
        StartCoroutine(Coroutine());
        hit.Play();
        myscore.score++;
        myscore.scoreText.text = "Score:" + myscore.score.ToString();

    }

    IEnumerator Coroutine()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<Renderer>().enabled = true;
    }
}
