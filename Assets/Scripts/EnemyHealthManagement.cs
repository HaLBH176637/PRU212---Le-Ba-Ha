using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManagement : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public HealthBarController healthUI;

    private bool _flashActive;
    private SpriteRenderer _enemySprite;
    [SerializeField]
    private float _flashLength = 0f;
    private float _flashCounter = 0f;

    void Start()
    {
        _enemySprite = GetComponent<SpriteRenderer>();
        healthUI.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (_flashActive)
        {
            HandleFlash();
        }
    }

    private void HandleFlash()
    {
        if (_flashCounter > 0f)
        {
            _flashCounter -= Time.deltaTime;
            _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, Mathf.PingPong(_flashCounter * 10, 1));
        }
        else
        {
            _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 1f);
            _flashActive = false;
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        healthUI.SetHealth(currentHealth);
        _flashActive = true;
        _flashCounter = _flashLength;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHealth(maxHealth);
        healthUI.SetHealth(maxHealth);
    }
}
