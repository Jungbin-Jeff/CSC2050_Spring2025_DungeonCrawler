using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(int hp, int maxHp)
    {
        slider.maxValue = maxHp;
        slider.value = hp;
    }
}
