using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject ball;
    public Text scoretext;

    private int Score1 =0, Score2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Score: " + Score1.ToString() + " " + Score2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.z < -29)
        {
            Score1 = Score1 + 1;
        }else if (ball.transform.position.z > 31)
        {
            Score2 = Score2 + 1;
        }
        scoretext.text = "Score: " + Score1.ToString() + " " + Score2.ToString();
    }
}
