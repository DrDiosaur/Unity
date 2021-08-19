using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    [SerializeField] private Text txtUI;
    public float _endNum = 0;
    
    public float duration;
    public float _startNum = 0;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        txtUI.text = _startNum.ToString();
        
    }

    void OnValueUpdate(float v)
    {
        txtUI.text = Mathf.Floor(v).ToString();
    }

    public void Counter(float resourceQuantity)
    {
        _startNum = _endNum;
        _endNum = _endNum + resourceQuantity;
        DOVirtual.Float(_startNum, _endNum, duration, OnValueUpdate);
    }


}
