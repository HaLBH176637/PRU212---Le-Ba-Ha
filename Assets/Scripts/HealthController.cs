using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text healthText;

    void Start()
    {
        slider.value = slider.maxValue;
        fill.color = gradient.Evaluate(1f);
        UpdateHealthText(slider.value, slider.maxValue);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        UpdateHealthText(health, slider.maxValue);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
        UpdateHealthText(health, health);
    }

    private void UpdateHealthText(float currentHealth, float maxHealth)
    {
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }
}
