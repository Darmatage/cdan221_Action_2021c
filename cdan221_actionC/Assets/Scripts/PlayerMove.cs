using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public AudioSource floatsound;
    public Animator animator;
    public Rigidbody2D rb2D;
    private bool FaceRight = true; // determine which way player is facing.
    public float runSpeed = 10f;
    public bool isAlive = true;
	private Vector3 hMove;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb2D = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
        hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (isAlive == true)
        {
            transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
			//rb2D.angularVelocity = 0f;
        }

         if (Input.GetAxis("Horizontal") != 0){ 
               animator.SetBool ("Walk", true); 
               if (!floatsound.isPlaying){ 
                     floatsound.Play(); 
               } 
         } else { 
            animator.SetBool ("Walk", false);
            floatsound.Stop(); 
         }

        // NOTE: if input is moving the Player right and Player faces left, turn, and vice-versa
        if ((hMove.x > 0 && !FaceRight) || (hMove.x < 0 && FaceRight))
        {
            playerTurn();
        }
		

    }


    void FixedUpdate()
    {
		//slow down on hills
		if (hMove.x == 0){
			rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y) ;
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

