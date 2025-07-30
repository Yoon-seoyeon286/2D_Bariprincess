using UnityEngine;
using UnityEngine.UI;


public class UIGameManager : MonoBehaviour
{
    public static UIGameManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindFirstObjectByType<UIGameManager>();
            }
            return m_instance;
        }
    }

    static UIGameManager m_instance;
    public Text LvText;
    public Text HeartBar;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
