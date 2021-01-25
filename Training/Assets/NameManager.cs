using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

public class NameManager : MonoBehaviour
{

    public List<string> names = new List<string>();

    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var name in names)
        {
            Debug.Log(name);
        }
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            names.Remove(names[Random.Range(0, names.Count)]);
            foreach (var name in names)
            {
                Debug.Log(name);
            }
        }
    }
}
