using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthBar healthplayer;
    private float waitToHurt = 2f;
    private bool isTouching;
    [SerializeField]
    private int damageToGive = 25;

    // Start is called before the first frame update
    void Start()
    {
        healthplayer = FindObjectOfType<HealthBar>();
        healthplayer.OnPlayerDeath += ResetScene; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthplayer.DamageToPlayer(damageToGive);
                waitToHurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthBar>().DamageToPlayer(damageToGive);
            isTouching = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
