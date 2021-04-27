using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public bool isAlive = true;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((Input.GetButtonDown("Jump")) && (IsGrounded()) && (isAlive == true))
        {
            Jump();
            //animator.SetBool("isJumping", true);
            animator.SetTrigger("Jump");
            //Debug.Log("isJumping true");
        }
        else if (IsGrounded())
        {
            //animator.SetBool("isJumping", false);
            //Debug.Log("isJumping false");
        }
        else 
        { 
            //animator.SetBool("isJumping", true); 
        }

    }

    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        //rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.25f, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 0.25f, enemyLayer);
        if ((groundCheck != null) || (enemyCheck != null))
        {
            return true;
            //Debug.Log("I can jump now!");
        }
        return false;
    }
}