using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealthManagement eHealth;
            eHealth = collision.gameObject.GetComponent<EnemyHealthManagement>();
            eHealth.HurtEnemy(damageToGive);
        }
    }
}
