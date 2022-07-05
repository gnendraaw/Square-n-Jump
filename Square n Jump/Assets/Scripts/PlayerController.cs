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
    private AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
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
            // play game over sfx
            audioManager.playAudio("GameOver");

            ScoreManager.singleton.updateScore();
            RunManager.singleton.gameOver();
        }

        // increase score if player hit score collider
        else if (collision.CompareTag("Score"))
        {
            ScoreManager.singleton.addScore();

            // play scoring sfx
            audioManager.playAudio("Score");
        }
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

            // play jump sfx
            audioManager.playAudio("Jump");
        }
    }
}
