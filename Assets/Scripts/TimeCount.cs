using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, second);
    }
}
