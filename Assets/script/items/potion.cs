using UnityEngine;

public class potion : MonoBehaviour, IItemUseable
{
    playercontroller player;
    public float amplitude = 0.05f;
    public float frequency = 3f;

    Vector2 startPosition;

    void Awake()
    {
        player = FindAnyObjectByType<playercontroller>();
    }

    void Start()
    {
        startPosition = transform.position;

    }

    void Update()
    {
        float newY = startPosition.y + amplitude * Mathf.Sin(Time.time * frequency);
        transform.position = new Vector2(startPosition.x, newY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ItemUse();
            Invoke("ItemOut", 0.3f);
        }
    }


    public void ItemUse()
    {
        player.AttackCount =0;
        UIGameManager.instance.Heart(-6);

    }

    void ItemOut()
    {
        Destroy(gameObject);
    }
}
