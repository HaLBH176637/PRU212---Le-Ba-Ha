using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowersUp/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        HealthBar healthBar = target.GetComponent<HealthBar>();
        if (healthBar != null)
        {
            healthBar.currentHealth += amount;
            if (healthBar.currentHealth > 0)
            {
                healthBar.currentHealth = healthBar.maxHealth;
            }
            healthBar.healthUI.SetHealth(healthBar.currentHealth); 
        }
        else
        {
            Debug.LogError("No HealthBar component found on target.");
        }
    }
}

