using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehavior is something Unity uses to allow us to connect our scripts to gameObjects.
public class PlayerController : MonoBehaviour
{
    // Creating variable for the rigidbody so we can controll the movement of the player.
    private Rigidbody2D rb;
    // To access our animations inside the FixedUpdate below
    private Animator animator;
    public float moveSpeed = 100;
    // Vector2 represents movement on the X and Y axis for 2D objects, (0,-1).
    private Vector2 input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // FixedUpdate also happens over and over (like void Update) but it is faster and runs before physics calculations. 
    void FixedUpdate()
    {
        // to prevent diagnal movement:
        if (input.x != 0) input.y = 0;
        // moves the player around by manipulating its velocity.
        rb.linearVelocity = new Vector2(input.x * moveSpeed * Time.deltaTime, input.y * moveSpeed * Time.deltaTime);
        // added this code, after creating idle char-animations to match our anims with the players movement:
        if (rb.linearVelocity != Vector2.zero)
        {
            animator.SetFloat("moveX", rb.linearVelocity.x);
            animator.SetFloat("moveY", rb.linearVelocity.y);
            // to check if the player is moving/walking:
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    // Update is called once per frame. We put things here that we want to happen repeatedly.    
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
