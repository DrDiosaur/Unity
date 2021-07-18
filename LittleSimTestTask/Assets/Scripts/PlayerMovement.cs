using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    private float movementSpeed;
    private Vector2 movementDirection;
    private Rigidbody2D rbody;
    private Animator _animator;

    private IInteractable _interactable;

    private static PlayerMovement instance;
    public int Gold { get; set; }

    public static PlayerMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerMovement>();
            }

            return instance;
        }
    }
    
    private void Awake()
    {
        Gold = 100;
        rbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
       GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rbody.velocity = movementDirection.normalized * movementSpeed;
        
    }

    private void GetInput()
    {
        
        movementDirection = Vector2.zero;
        
        if (Input.GetKey("w"))
        {
            movementDirection = Vector2.up;
            //transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
            _animator.Play("PlayerUp");
            
        }else if (Input.GetKey("d"))
        {
            movementDirection = Vector2.right;
            //transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            _animator.Play("PlayerRight");
        }else if (Input.GetKey("a"))
        {
            movementDirection = Vector2.left;
            //transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            _animator.Play("PlayerLeft");
        }else if (Input.GetKey("s"))
        {
            movementDirection = Vector2.down;
            //transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
            _animator.Play("PlayerDown");
        }
        else
        {
            _animator.Play("PlayerIdle");
        }
    }

    public void Interact()
    {
        if (_interactable != null)
        {
            _interactable.Interact();
            Debug.Log("Interacted");
        }
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "ShopKeeper")
        {
            _interactable = other.collider.GetComponent<IInteractable>();
            Interact();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "ShopKeeper")
        {
            if (_interactable != null)
            {
                _interactable.StopInteract();
                _interactable = null;
            }
            
        }
    }
}
