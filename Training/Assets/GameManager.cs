using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _speed;

    public float Speed
    {
        get { return _speed; }
        private set { _speed = value; }
    }
    
    private string _name;
    
    public string Name
    {

        get { return _name; }

        set
        {
            _name = value;
            Debug.Log("AAAAAAAAAA");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Speed = 10f;
        Debug.Log(Speed);
        Name = "Andriy";
        Debug.Log(Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
