using UnityEngine;

public class Bee : MonoBehaviour
{
    Animator animator;
    public playercontroller player;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("Attack");
        }
    }




}
