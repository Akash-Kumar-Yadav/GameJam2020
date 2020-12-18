using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    [SerializeField] TMP_Text header;
    [SerializeField] TMP_Text infectedText;
    [SerializeField] TMP_Text noMasktext;
    [SerializeField] RectTransform gameOverBody;

    public static bool b_gameOver = false;

    public float Delay;
    [SerializeField] Ease ease;
    [SerializeField] CanvasGroup canvasGroup;   

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver(int infected, int noMasked,string title)
    {
        b_gameOver = true;
        infectedText.text = "Infected Remaining: " + infected;
        noMasktext.text = "No Mask Remaining: " + noMasked;
        header.text = title;
       
        canvasGroup.DOFade(.8f, 1);
        gameOverBody.DOAnchorPosY(-70, Delay).SetEase(ease).SetDelay(1);

    }
}
