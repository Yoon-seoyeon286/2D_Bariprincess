using System.Security.Cryptography;
using System.Xml.Serialization;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.SpeedTree.Importer;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playercontroller : MonoBehaviour
{

    //run
    public float speed = 8f;

    //jump
    public float jumpCount = 0;
    bool isGrounded = false;
    public float jumpForce = 100f;

    //Dead
    bool isDead = false;

    //HP
    int HP = 90;
    public HPBar hPBar;
    int AttackCount = 0;

    //Attack
    Bee bee;
    public GameObject bees;


    //etc
    Rigidbody2D rb;
    Animator animator;
    public AudioClip deathclip;

    //Level


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        HP = 90;
        AttackCount = 0;

        bee = FindFirstObjectByType<Bee>();

    }


    void Update()
    {

        if (isDead)
        {
            return;
        }

        float xInput = Input.GetAxis("Horizontal");

        if (isGrounded)
        {
            if (xInput != 0)
            {

                rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
                animator.SetBool("Run", true);
            }

            else
            {
                animator.SetBool("Run", false);
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(xInput * 1.2f, rb.linearVelocity.y);
        }




        animator.SetBool("Jump", !isGrounded);
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }


    public void Die()
    {
       
        rb.linearVelocity = Vector2.zero;
        isDead = true;

        SceneManager.LoadScene("01Scene");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead) //추락 시 사망
        {
            Die();
        }

        if (collision.tag == "Finish") //골인하면 다음 씬
        {
            SceneManager.LoadScene("02Scene");
        }

        if (collision.tag == "Enemy") //닿으면 체력 감소
        {
            AttackCount++;

            if (AttackCount <= 2)
            {
                hPBar.DamageHeart1();
            }

            if (2 < AttackCount && AttackCount <= 4)
            {
                hPBar.DamageHeart2();
            }

            if (4 < AttackCount && AttackCount <= 6)
            {
                hPBar.DamageHeart3();
                animator.SetTrigger("Dead");
                Invoke("Die", 2.5f);
            }
        }
    }

    public void onAttack()
    {
        animator.SetTrigger("Attack");

    }

    public void DealAttackDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1.5f);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Bee bee = hit.GetComponent<Bee>();
                if (bee != null)
                {
                    bee.hitSlide(25);
                }
            }
        }
    }


}

