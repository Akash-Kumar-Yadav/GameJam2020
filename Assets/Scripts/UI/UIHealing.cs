using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIHealing : MonoBehaviour
{
    [SerializeField] Image fillbar;
    [SerializeField] GameObject BG;
    [SerializeField] TMP_Text money;

    public void Healing(float progress,float maxTime)
    {
        BG.gameObject.SetActive(true);
       
        fillbar.fillAmount =  progress/maxTime ;
        if(fillbar.fillAmount >= 1)
        {
            BG.gameObject.SetActive(false);
            money.gameObject.SetActive(true);
            money.text = "$300";          
            money.rectTransform.DOScale(.01f, 2);
        }
    }

    

}
