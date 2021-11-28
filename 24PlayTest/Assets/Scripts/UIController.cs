using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private Text _text;


    private void Awake()
    {
        _text = playButton.GetComponentInChildren<Text>();
        playButton.onClick.AddListener(() => ChangeText());
        playButton.onClick.AddListener(() => UnpauseGame());
        exitButton.onClick.AddListener(() => Application.Quit());
    }


    private void ChangeText()
    {
        _text.text = "Resume Game";
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1f;
        PauseControl.gameIsPaused = false;
    }
}
