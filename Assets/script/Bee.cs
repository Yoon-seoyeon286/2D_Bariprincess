using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour, IDamageable, IItemable
{
    Animator animator;
    UIGameManager UIManger;
    public playercontroller player;
    public RawImage imgBar;
    public GameObject[] items;
    int hp = 100;

    public Vector2 direction;
    SpriteRenderer render;

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        UIManger = FindAnyObjectByType<UIGameManager>();
        animator = GetComponent<Animator>();
    }


    void Start()
    {

        hp = 100;

    }

    void Update()
    {
        // 오른쪽 방향 레이캐스트
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right, 15f);
        // 왼쪽 방향 레이캐스트  
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, 15f);

        if (rightHit.collider != null && rightHit.collider.CompareTag("Player"))
        {
            render.flipX = true; // 플레이어가 오른쪽에 있으면 오른쪽을 봄
        }
        else if (leftHit.collider != null && leftHit.collider.CompareTag("Player"))
        {
            render.flipX = true; // 플레이어가 왼쪽에 있으면 왼쪽을 봄 (flip)
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
        UIManger.LevelSystem(5);
        UIManger.ScoreSystem(10);
        gameObject.SetActive(false);
        itemDrop();
    }


    public void Damage(int damage)
    {
        if (hp <= 0)
        {
            return;
        }

        hp -= damage;
        imgBar.transform.localScale = new Vector3(0.4f * hp / 100f, 0.028f, 1f);

        if (hp <= 0)
        {
            Die();
        }

    }

    public void itemDrop()
    {
        Vector3 spawnPosition = transform.position + Vector3.up * 1f;
        int randomItem = Random.Range(0, items.Length);
        Instantiate(items[randomItem], spawnPosition, Quaternion.identity);
    }


    public void PlayerDamage()
    {
        player.PlayerDamage();
    }
}
