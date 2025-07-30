using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    Animator animator;
    UIGameManager UIManger;
    public playercontroller player;
    public RawImage imgBar;
    int hp = 100;



    void Start()
    {
        UIManger = FindAnyObjectByType<UIGameManager>();
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
        imgBar.transform.localScale = new Vector3(0.4f*hp / 100f, 0.028f,1f);

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

    public void Die()
    {
        gameObject.SetActive(false);
        UIManger.LevelSystem(5);
    }




}
