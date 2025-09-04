using UnityEngine;

public class Sword : MonoBehaviour
{
    UIGameManager UIManager;
    IDamageable currentTarget;
   [SerializeField] float attackRange = 3f;
    public int plusDamage =0;


    private void Awake()
    {
        UIManager = FindAnyObjectByType<UIGameManager>();
       
    }

  

    private void OnTriggerStay2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponentInParent<IDamageable>(); 
        if(damageable != null)
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if(distance < attackRange)
            {
                currentTarget = damageable;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponentInParent<IDamageable>();
        if (damageable != null && damageable == currentTarget)
        {
            currentTarget = null;
        }

    }

    public void SwordAttack(int damage)
    {
        int totalDamage = 0;
        totalDamage += damage;
        totalDamage += plusDamage;

        if(currentTarget != null)
        {
            currentTarget.Damage(totalDamage);
            currentTarget = null;
        }
    }


}
