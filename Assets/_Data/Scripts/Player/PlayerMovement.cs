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

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    public bool isGrounded = false;
    [SerializeField]
    LayerMask groundMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

	private void FixedUpdate()
	{
        isGrounded = groundRaycast();

        if (Input.GetKey(KeyCode.A))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(speedGrounded * -1, rb.velocity.y);
            }else
            {
                rb.velocity = new Vector2(speedJumped * -1, rb.velocity.y);
            }

            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(speedGrounded, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speedJumped, rb.velocity.y);
            }

            sr.flipX = false;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

	private bool groundRaycast()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundMask);
    }
}
