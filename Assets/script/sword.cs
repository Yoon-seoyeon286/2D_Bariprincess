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


    public void DealswordAttack(int damage)
    {
        bee.hitSlide(damage);
    }

 
} 
