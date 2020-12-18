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

    [SerializeField] GameObject gameOver;
    InfectAI infectAi;

    [SerializeField] GameOverScript gameOverScript;
    private void Start()
    {
        infectAi = FindObjectOfType<InfectAI>();
        gameOver.SetActive(false);
        
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, 300);
        float min = Mathf.FloorToInt(timer / 60);
        float sec = Mathf.FloorToInt(timer % 60);

        timeText.text = DateTime.Now.ToString();
        timerText.text = string.Format("{0:00}:{1:00}",min,sec);
        
        if(timer <= 0)
        {
            gameOver.SetActive(true);
            gameOverScript.GameOver(infectAi.getInfected, infectAi.getNoMask, "Time's Up");
        }

        if(infectAi.getInfected == 0 && infectAi.getNoMask == 0)
        {
            gameOver.SetActive(true);
            gameOverScript.GameOver(infectAi.getInfected, infectAi.getNoMask, "Congraulations");
        }
    }
}
