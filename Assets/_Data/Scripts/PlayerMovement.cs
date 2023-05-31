using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    public bool isGrounded = false;
    [SerializeField] LayerMask groundMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            sr.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector3.up * jumpForce * Time.deltaTime;
        }
    }

	private void FixedUpdate()
	{
        isGrounded = groundRaycast();
	}

	private bool groundRaycast()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.7f, groundMask);
    }
}
