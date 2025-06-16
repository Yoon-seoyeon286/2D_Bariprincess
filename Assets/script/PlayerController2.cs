using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;

    int jumpCount = 0;
    bool isGrounded = false;
    bool isDead = false;

    Rigidbody2D rb;
    Animator animator;
    AudioSource playerAudio;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        animator.SetBool("Grounded", isGrounded);
        
    }

    public void Jump()
    {
        if (jumpCount >= 2) return;

        jumpCount++;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(0, jumpForce));


        if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = rb.linearVelocity * 0.5f;
        }

    }

    void Die()
    {
        animator.SetTrigger("Die");
        rb.linearVelocity = Vector2.zero;
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
