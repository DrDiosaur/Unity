using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite;
    
    public float moveSpeed;

    public float jumpForce;

    private Rigidbody2D rb;
    private Collider2D myCollider;

    public bool isGrounded;

    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        
        
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.Play("Player_Jump");
                
            }
        }else if (!isGrounded)
        {
            animator.Play("Player_Fall");
        }
        else
        {
            animator.Play("Player_Run");
        }
        
    }
}
