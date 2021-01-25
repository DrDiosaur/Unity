using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    public float timeStart = 5;

    
    public Button button;
    public Text timerText;
    public Text buttonText;
    public Score scoreS;
    public AudioSource gameEnd;
    
    public bool timerRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonText.enabled == false)
        {
            buttonText.text = "Start";
        }
        if (timerText.enabled == false)
        {
            timerRunning = false;
        }
        if (timerRunning == true)
        {
            timeStart -= Time.deltaTime;
            timerText.text = Mathf.Round(timeStart).ToString();
            if (timerText.text == "0")
            {
                timerRunning = false;
                gameEnd.Play();
                button.gameObject.SetActive(false);
                scoreS.scoreText.transform.position = new Vector3(500, 300, 0);
            }
        }
        
    }

    public void ButtonTimer()
    {
        timerRunning = !timerRunning;

        buttonText.text = timerRunning ? "Pause" : "Start";
    }

    public void ResetTimer()
    {
        timerRunning = false;
        button.gameObject.SetActive(true);
        timeStart = 30;
        timerText.text = "30";
        buttonText.text = "Start";
        scoreS.score = 0;
        scoreS.scoreText.text = "Score:" + scoreS.score.ToString();
        scoreS.scoreText.transform.position = new Vector3(900, 550, 0);
    }
    
}
