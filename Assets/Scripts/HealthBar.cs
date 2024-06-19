using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public HealthBarController healthUI;
    public event System.Action OnPlayerDeath;

    private bool _flashActive;
    private SpriteRenderer _playerSprite;
    [SerializeField]
    private float _flashLength = 0f;
    private float _flashCounter = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        
        if (healthUI == null)
        {
            healthUI = FindObjectOfType<HealthBarController>();
            if (healthUI == null)
            {
                Debug.LogError("HealthBarController not found in the scene. Please assign it in the Inspector.");
                return; 
            }
        }
        healthUI.SetMaxHealth(maxHealth);
        _playerSprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (_flashActive)
        {
            if (_flashCounter > _flashLength * .99f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 0f);
            }
            else if (_flashCounter > _flashLength * .89f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 1f);
            }
            else if (_flashCounter > _flashLength * .79f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 0f);
            }
            else if (_flashCounter > _flashLength * .69f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 1f);
            }
            else if (_flashCounter > _flashLength * .59f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 0f);
            }
            else if (_flashCounter > _flashLength * .49f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 1f);
            }
            else if (_flashCounter > _flashLength * .39f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 0f);
            }
            else if (_flashCounter > _flashLength * .29f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 1f);
            }
            else if (_flashCounter > _flashLength * .19f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 0f);
            }
            else if (_flashCounter > _flashLength * .9f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 1f);
            }
            else if (_flashCounter > 0f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 0f);
            }
            else
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 1f);
                _flashActive = false;
            }
            _flashCounter -= Time.deltaTime;
        }
    }

    public void DamageToPlayer(int damage)
    {
        currentHealth -= damage;
        healthUI.SetHealth(currentHealth);
        _flashActive = true;
        _flashCounter = _flashLength;
        if (currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
