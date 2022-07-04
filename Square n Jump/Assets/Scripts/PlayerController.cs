using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float radius;
    public Transform groundCheckPos;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jump();
    }

    // draw gizmos for ground checking area
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheckPos.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            ScoreManager.singleton.updateScore();
            RunManager.singleton.gameOver();
        }

        // increase score if player hit score collider
        else if (collision.CompareTag("Score"))
            ScoreManager.singleton.addScore();
    }

    // return true if groundChecker hits ground layer
    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, radius, whatIsGround);
    }

    void jump()
    {
        // if player hits space button and char's on ground
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
