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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheckPos.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            audioManager.playAudio("GameOver");
            ScoreManager.singleton.updateScore();
            RunManager.singleton.gameOver();
        }
        else if (collision.CompareTag("Score"))
        {
            ScoreManager.singleton.addScore();
            audioManager.playAudio("Score");
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, radius, whatIsGround);
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;
            audioManager.playAudio("Jump");
        }
    }
}
