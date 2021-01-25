using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Main.onTeleport += Spawn;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Spawn(Vector3 pos)
    {
        transform.position = pos;
    }

    private void OnDisable()
    {
        Main.onTeleport -= Spawn;
    }
}
