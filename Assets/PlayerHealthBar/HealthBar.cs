using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;     // variables

    public void SetSlider(float amount)
    {                                           // checking the health of the player
        healthSlider.value = amount;
    }

    public void SetSliderMax(float amount)
    {                                           // setting the max health of the player
        healthSlider.maxValue = amount;
        SetSlider(amount);
    }
}
