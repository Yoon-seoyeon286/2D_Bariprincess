using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    Animator animator;
    public playercontroller player;
    public RawImage imgBar;
    int hp = 100;


    void Start()
    {
        animator = GetComponent<Animator>();
        hp = 100;

    }

    void Update()
    {

    }

    public void hitSlide(int amount)
    {
        if (hp <= 0)
        {
            return;
        }

        hp -= amount;
        imgBar.transform.localScale = new Vector2(hp / 250, 0);

        if (hp <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("Attack");
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }




}
