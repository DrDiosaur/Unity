using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    private Button pauseButton;
    public static bool gameIsPaused;

    private void Awake()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(PauseGame);
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
