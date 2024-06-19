using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect PowerUpEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        PowerUpEffect.Apply(collision.gameObject);
    }
}
