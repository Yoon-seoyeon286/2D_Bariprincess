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
    int LevelScore = 1;
    int ContainerLevelScore = 0;

    public Image[] HeartImage; //HP

    public Text ScoreText; //score
    int scoreNumber = 0;

    private void Start()
    {
        scoreNumber = 0;
    }

    public void Heart(int damageCount)
    {
        int hearCount = 0;
        hearCount += damageCount;

        if (hearCount <= 2)
        {
            HeartImage[0].fillAmount -= 0.5f;
        }

        if (2 < hearCount && hearCount <= 4)
        {
            HeartImage[1].fillAmount -= 0.5f;
        }

        if (4 < hearCount && hearCount <= 6)
        {

            HeartImage[2].fillAmount -= 0.5f;
        }

        else if (hearCount < 0)
        {
            HeartImage[0].fillAmount = 1;
            HeartImage[1].fillAmount = 1;
            HeartImage[2].fillAmount = 1;

            hearCount = 0;
        }
    }

    public void LevelSystem(int Energy)
    {
        
        ContainerLevelScore+= Energy;

        if (ContainerLevelScore % 10 == 0)
        {
            LevelScore++;
            LvText.text = "Lv. " + LevelScore;
        }
    }

    public void ScoreSystem(int amount)
    {
        
        scoreNumber += amount;

        ScoreText.text = scoreNumber.ToString();
    }
}

