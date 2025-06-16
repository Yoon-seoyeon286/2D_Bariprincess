using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    static int level;
    int score;
    public Text levelText;
    int leveling = 1;

    void Start()
    {
        score = 0;
    }


    void Update()

    {
        if (score >= 10)
        {
            ++leveling;
            levelText.text = "Lv." + leveling;
        }

    }

    public void attackScore(int amount)
    {
        score+=amount;
    }
}
