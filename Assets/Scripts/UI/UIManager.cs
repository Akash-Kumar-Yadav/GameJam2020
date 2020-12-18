using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform main;
    [SerializeField] RectTransform howToPlay;
    [SerializeField] RectTransform setting;
    [SerializeField] RectTransform quit;
    [SerializeField] float endValue;

    public void HowToPlay()
    {
        //main.SetActive(false);
        main.transform.GetComponent<CanvasGroup>().DOFade(0, .2f);
        main.DOAnchorPosX(-2000, 1);
        howToPlay.DOAnchorPosX(endValue, 1);
    }
    public void Settings()
    {
        main.transform.GetComponent<CanvasGroup>().DOFade(0, .2f);
        main.DOAnchorPosX(-2000, 1);
        setting.DOAnchorPosX(endValue, 1);
    }

    public void Back(RectTransform obj)
    {
        obj.DOAnchorPosX(-2000, 1);
        main.transform.GetComponent<CanvasGroup>().DOFade(1, .2f);
        main.DOAnchorPosX(0, 1);
    }
    public void QuitMenu()
    {
        Application.Quit();
    }

    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
