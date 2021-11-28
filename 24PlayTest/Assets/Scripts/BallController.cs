using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private List<GameObject> bricks;
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject player;
    private Rigidbody rigidbody;
    private Transform arrow;
    private int level = 1;
    private Vector3 startPos;
    private Vector3 enemyStartPos;
    public static bool ballIsLaunched = false;
    public int bricksQ = 3;
    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        arrow = GetComponentInChildren<Transform>();
        startPos = transform.position;
        enemyStartPos = enemy.transform.position;
        levelText.text = "Level:" + level;
        
    }

    private void Update()
    {

        if (bricksQ == 0)
        {
            foreach (var brick in bricks)
            {
                brick.SetActive(true);
                
            }

            enemy.GetComponent<EnemyController>().speed += 0.5f;
            
            level += 1;
            levelText.text = "Level:" + level;
            bricksQ = 3;
        }
    }

    public void LaunchBall()
    {
        rigidbody.velocity = transform.forward * (arrow.localScale.x * 20);
        
        
        ballIsLaunched = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy") || other.collider.CompareTag("Bricks"))
        {
            ballIsLaunched = false;
            rigidbody.velocity = Vector3.zero;
            transform.position = startPos;
            enemy.transform.position = enemyStartPos;
            
            player.SetActive(true);
            if (other.collider.CompareTag("Bricks"))
            {
                other.gameObject.SetActive(false);
                bricksQ -= 1;
            }
        }
        
        
        
    }
}
