using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float period;
    [SerializeField]
    private float time;
    private List<GameObject> poolEnemy = new List<GameObject>();
    private int activeEnemyCount = 0;
    private int deactiveEnemyCount = 0;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            CreateNewEnemy();
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= period)
        {
            SpawnEnemy();
            time = 0;
        }
    }

    private void SpawnEnemy()
    {
        int indexEnemy = FindEnemy();
        if (indexEnemy != -1)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-26f, -15f), Random.Range(16f, 5f), 0);
            GameObject enemy = poolEnemy[indexEnemy];
            enemy.transform.position = spawnPosition;

            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.homePos.position = spawnPosition;
            }

            enemy.SetActive(true);
            activeEnemyCount++;
        }
    }

    private int FindEnemy()
    {
        for (int i = 0; i < poolEnemy.Count; i++)
        {
            if (!poolEnemy[i].activeInHierarchy)
            {
                return i;
            }
        }
        CreateNewEnemy();
        return poolEnemy.Count - 1;
    }

    private void CreateNewEnemy()
    {
        GameObject gameObject = Instantiate(prefab);
        poolEnemy.Add(gameObject);
        gameObject.SetActive(false);
        EnemyController enemyController = gameObject.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController._speed = Random.Range(2.0f, 4.0f);
            GameObject homePosObject = new GameObject("HomePosition");
            homePosObject.transform.position = gameObject.transform.position;
            enemyController.homePos = homePosObject.transform;
        }
    }

    public void EnemyDeactivated()
    {
        deactiveEnemyCount++;
    }

    public int EnemyActivatedCount()
    {
        return activeEnemyCount;
    }

    public int EnemyCountDeactivated()
    {
        return deactiveEnemyCount;
    }
}