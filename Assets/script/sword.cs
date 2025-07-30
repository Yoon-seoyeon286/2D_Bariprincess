using UnityEngine;

public class sword : MonoBehaviour
{
    UIGameManager UIManager;
    Bee bee;
    

    private void Awake()
    {
        bee = FindAnyObjectByType<Bee>();
        UIManager = FindAnyObjectByType<UIGameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            bee.hitSlide(20);
        }
    }
}
