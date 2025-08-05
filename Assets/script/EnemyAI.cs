using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1.0f;
    public float detectionRange = 1.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed*Time.deltaTime);
        }
    }
}
