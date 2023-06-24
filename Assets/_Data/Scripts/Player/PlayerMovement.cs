using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speedGrounded;
    [SerializeField]
    private float speedJumped;
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Animator anim;
    
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    public bool isGrounded = false;
    public bool isCeling = false;
    [SerializeField] LayerMask groundMask;

    private int dir = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

	private void FixedUpdate()
    {
        isGrounded = groundRaycast();
        isCeling = celingRaycast();
        
        anim.SetBool("isWalking", false);
        
        if (Input.GetKey(KeyCode.A))
        {
            if (isGrounded)
            {
                anim.SetBool("isWalking", true);
                rb.velocity = new Vector2(speedGrounded * -1, rb.velocity.y);
            }else
            {
                //anim.SetBool("Jumping", true);
                rb.velocity = new Vector2(speedJumped * -1, rb.velocity.y);
            }

            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (isGrounded)
            {
                anim.SetBool("isWalking", true);
                rb.velocity = new Vector2(speedGrounded, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speedJumped, rb.velocity.y);
            }

            sr.flipX = false;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded && !isCeling)
        {
            anim.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        // Falling animation
        if (rb.velocity.y < 0f && !isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
            
        }
        else if(rb.velocity.y==0 && isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        

    }

    private bool groundRaycast()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundMask);
    }
    
    private bool celingRaycast()
    {
        return Physics2D.Raycast(transform.position, Vector2.up, 1f, groundMask);
    }
}
