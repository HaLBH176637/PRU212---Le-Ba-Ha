using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeathUI : MonoBehaviour
{
    [SerializeField] Text txtEnemyDeath;
    [SerializeField] Text txtBestScore;  
    [SerializeField] EnemySpawn enemyDeath;

    private int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);  
        UpdateBestScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDeath != null && txtEnemyDeath != null)
        {
            int currentDeactivatedCount = enemyDeath.EnemyCountDeactivated();
            txtEnemyDeath.text = " : " + currentDeactivatedCount.ToString();

            if (currentDeactivatedCount > bestScore)
            {
                bestScore = currentDeactivatedCount;
                PlayerPrefs.SetInt("BestScore", bestScore);  
                UpdateBestScoreUI();
            }
        }
    }

    private void UpdateBestScoreUI()
    {
        if (txtBestScore != null)
        {
            txtBestScore.text = " : " + bestScore.ToString();
        }
    }
}
