using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider;

    public void UpdateHealthBar(float healthRatio)
    {
        healthSlider.value = healthRatio;
    }
}
