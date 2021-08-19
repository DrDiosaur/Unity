using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AlertScript : MonoBehaviour
{
    [SerializeField] private Text txtUI;
    [SerializeField] private Transform camera;
    
    private string txt = "";
    
   
    public float txtDuration;
    public string targetTxt;
    public string tt = "";

    private void Awake()
    {
        camera = Camera.main.transform;
    }

    public void ShowText()
    {
        DOTween.Sequence()
            .Append(DOTween.To(() => txt, x => txt = x, targetTxt, txtDuration).OnUpdate(() => txtUI.text = txt))
            .Append(DOTween.To(() => txt, x => txt = x, tt, txtDuration).OnUpdate(() => txtUI.text = txt));
        
        
        camera.DOShakePosition(1);

    }
}
