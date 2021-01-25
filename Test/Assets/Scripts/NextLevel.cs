using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public GameObject[] blocks;
    public Text lvltext;
    public EnemyMovement _enemy;

    private int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        lvltext.text = "Level: " + level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        bool allTrue = false;
        foreach (GameObject block in blocks)
        {
            if (block.active == false)
            {
                allTrue = true;
            }
            else
            {
                allTrue = false;
                break;
            }
        }

        if (allTrue)
        {
            foreach (GameObject block in blocks)
            {
                block.SetActive(true);
            }

            level++;
            lvltext.text = "Level:" + level.ToString();
            _enemy.speed = _enemy.speed + 50;
        }
    }
}
