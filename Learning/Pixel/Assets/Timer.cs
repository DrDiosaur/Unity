using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{

    [SerializeField] private TextMesh textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    private void Update()
    {
        Clock();
    }

    void Clock()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero( time.Hour );
        string minute = LeadingZero( time.Minute );
        string second = LeadingZero( time.Second );
        
        textMesh.text = hour + ":" + minute + ":" + second;
    }
    
    
    string LeadingZero (int n){
        return n.ToString().PadLeft(2, '0');
    }
}
