using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    
    public List<GameObject> objs = new List<GameObject>();
    public List<GameObject> ObjectsCreated = new List<GameObject>();
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjSpawner();
        }
    }

    void ObjSpawner()
    {
        GameObject ObjectToSpawn = objs[Random.Range(0, objs.Count)];
        if (ObjectsCreated.Count <= 9)
        {
            
            ObjectToSpawn.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 10);
            GameObject go = Instantiate(ObjectToSpawn);
            ObjectsCreated.Add(go);
        }else{
            foreach (var obj in ObjectsCreated)
            {
                obj.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            ObjectsCreated.Clear();
            
        }
    }
}
