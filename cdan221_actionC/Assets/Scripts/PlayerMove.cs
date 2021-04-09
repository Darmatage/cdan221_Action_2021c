using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //public Animator animator;
    public Rigidbody2D rb2D;
    private bool FaceRight = true; // determine which way player is facing.
    public float runSpeed = 10f;
    public bool isAlive = true;

    void Start()
    {
        //animator = gameObject.GetComponentInChildren<Animator>();
        rb2D = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
        Vector3 hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (isAlive == true)
        {
            
            transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
        }

        // if (Input.GetAxis("Horizontal") != 0){
        //       animator.SetBool ("Walk", true);
        // } else {animator.SetBool ("Walk", false);}

        // NOTE: if input is moving the Player right and Player faces left, turn, and vice-versa
        if ((hMove.x > 0 && !FaceRight) || (hMove.x < 0 && FaceRight))
        {
            playerTurn();
        }
    }

    private void playerTurn()
    {
        // NOTE: Switch player facing label
        FaceRight = !FaceRight;

        // NOTE: Multiply player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
