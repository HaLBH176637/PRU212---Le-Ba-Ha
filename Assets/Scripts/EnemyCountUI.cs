using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCountUI : MonoBehaviour
{
    [SerializeField] Text txtEnemy;
    [SerializeField] EnemySpawn enemySpawner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawner != null & txtEnemy != null)
        {
            txtEnemy.text = " : " + enemySpawner.EnemyActivatedCount().ToString();
        }
    }

}
