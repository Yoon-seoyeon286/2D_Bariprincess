using UnityEngine;

public class sword : MonoBehaviour
{
    UIGameManager UIManager;
    IDamageable currentTarget;
   [SerializeField] float attackRange = 3f;


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
        if(currentTarget != null)
        {
            currentTarget.Damage(damage);
            currentTarget = null;
        }
    }


}
