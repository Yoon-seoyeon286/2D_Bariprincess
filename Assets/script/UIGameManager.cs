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


    public Text LvText; //level
    int LevelScore = 0;

    public Image[] HeartImage; //HP

    public Text ScoreText; //score

    public void Heart(int damageCount)
    {
        if (damageCount <= 2)
        {
            HeartImage[0].fillAmount -= 0.5f;
        }

        if (2 < damageCount && damageCount <= 4)
        {
            HeartImage[1].fillAmount -= 0.5f;
        }

        if (4 < damageCount && damageCount <= 6)
        {

            HeartImage[2].fillAmount -= 0.5f;
        }
    }

    public void LevelSystem(int Energy)
    {
        if (Energy % 10 == 0)
        {
            LevelScore++;
            LvText.text = "Lv. " + LevelScore;
        }
    }

}

