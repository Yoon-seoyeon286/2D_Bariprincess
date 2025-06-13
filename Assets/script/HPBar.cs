using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image[] images;

    public void DamageHeart1()
    {

        images[0].fillAmount -= 0.5f;
    }

    public void DamageHeart2()
    {
        images[1].fillAmount -= 0.5f;
    }

    public void DamageHeart3()
    {
        images[2].fillAmount -= 0.5f;
    }
}
