using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private Transform target;
    public Transform homePos;

    public float _speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    [SerializeField]
    private int health = 100; 
    private int damage = 25; 



    void Start()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if (target == null || homePos == null)
        {
            return;
        }

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= maxRange && distanceToTarget >= minRange)
        {
            FollowPlayer();
        }
        else if (distanceToTarget > maxRange)
        {
            HomePos();
        }
    }

    public void FollowPlayer()
    {
        anim.SetBool("isMoving", true);
        anim.SetFloat("moveX", target.position.x - transform.position.x);
        anim.SetFloat("moveY", target.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);
    }

    public void HomePos()
    {
        anim.SetFloat("moveX", homePos.position.x - transform.position.x);
        anim.SetFloat("moveY", homePos.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position);
            transform.position = new Vector2(transform.position.x + knockbackDirection.x, transform.position.y + knockbackDirection.y);
            TakeDamage(damage);
        }
    }

    private void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
     
        gameObject.SetActive(false);
        if (homePos != null && FindObjectOfType<EnemySpawn>() != null)
        {
            FindObjectOfType<EnemySpawn>().EnemyDeactivated();
        }
    }


    void OnDisable()
    {
        if (transform.parent != null)
        {
            EnemySpawn enemySpawn = transform.parent.GetComponent<EnemySpawn>();
            if (enemySpawn != null)
            {
                enemySpawn.EnemyDeactivated();
            }
        }
    }
}
