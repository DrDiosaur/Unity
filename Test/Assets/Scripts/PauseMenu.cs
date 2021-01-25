using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public Button _button;
    private Rigidbody rb;
    public GameObject player;
    public GameObject pauseMenu;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _button.onClick.AddListener(PressButton);
        
        rb = player.GetComponent<Rigidbody>();
            
        
        

    }

    void PressButton()
    {
        
        if (_button.name == "Pause")
        {
            
            pauseMenu.SetActive(true);
            Time.timeScale = 0.00001f;
            
                
            
        }else if (_button.name == "QuitButton")
        {
            Application.Quit();
        }else if (_button.name == "ResumeButton")
        {

            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            
            
            
            


        }else{
            SceneManager.LoadScene("SampleScene");
        }
    }
}
