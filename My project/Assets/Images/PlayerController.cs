using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.5f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");

        // Check horizontal input for movement and update player direction.
        if (axisH > 0.0f)
        {
            Debug.Log("Moving right");
            transform.localScale = new Vector2(1, 1); // Flip the player's sprite to face right.
        }
        else if (axisH < 0.0f)
        {
            Debug.Log("Moving left");
            transform.localScale = new Vector2(-1, 1); // Flip the player's sprite to face left.
        }

        // Check for jump input.
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Check if the player is on the ground using a linecast.
        onGround = Physics2D.Linecast(transform.position,
                                      transform.position - (transform.up * 0.1f),
                                      groundLayer);

        // Apply horizontal movement when on the ground or in the air.
        if (onGround || axisH != 0)
        {
            rbody.velocity = new Vector2(speed * axisH, rbody.velocity.y);
        }

        // Check for jumping conditions and apply an impulse force when ready.
        if (onGround && goJump)
        {
            Debug.Log("Jumping");
            Vector2 jumpPw = new Vector2(0, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }
    }

    // Call this method to initiate a jump.
    public void Jump()
    {
        goJump = true;
        Debug.Log("Jump button pressed!");
    }
}
