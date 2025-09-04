using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<ItemManager>();
            }

            return m_instance;
        }
    }

    static ItemManager m_instance;

    public GameObject sideFire;
    public Sword sword;

    public IEnumerator OffEnergy()
    {
        yield return new WaitForSeconds(8f);
        sideFire.SetActive(false);
        sword.plusDamage = -10;
    }
}
