using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3[] positions;

    private int _randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        _randomIndex = GetRandom();

        Debug.Log("RandomIndex: " + _randomIndex);

        transform.position = GetAllPositions();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UtilityHelper.ChangeColor(this.gameObject);
        }
    }

    int GetRandom()
    {
        return Random.Range(0, positions.Length);
    }
    
    Vector3 GetAllPositions()
    {
        return positions[_randomIndex];
    }
    
}
