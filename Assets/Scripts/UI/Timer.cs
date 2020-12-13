using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] float timer = 300;
    

    private void Update()
    {
        timer -= Time.deltaTime;
        float min = Mathf.FloorToInt(timer / 60);
        float sec = Mathf.FloorToInt(timer % 60);
        timeText.text = DateTime.Now.ToString();
        timerText.text = string.Format("{0:00}:{1:00}",min,sec);
    }
}
