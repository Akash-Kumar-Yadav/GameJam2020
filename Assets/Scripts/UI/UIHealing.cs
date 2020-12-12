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
    [SerializeField] TMP_Text fineText;
    private int docFine = 300;
    private int copFine = 600;
    private static int currentFine = 0;

    [SerializeField] InfectAI infectAI;

    public void Healing(float progress,float maxTime,string tag)
    {
        BG.gameObject.SetActive(true);
       
        fillbar.fillAmount =  progress/maxTime ;
        if(fillbar.fillAmount >= 1)
        {
            BG.gameObject.SetActive(false);
            
           if(tag == "Infected" && gameObject.transform.parent.tag == "Doc")
           {
                money.gameObject.SetActive(true);
                money.text = "$"+docFine;
                currentFine += docFine;
                fineText.text = "$" + currentFine;
                infectAI.SubInfected();
                money.rectTransform.DOScale(.01f, 2);
           }
            else if (tag == "NoMask" && gameObject.transform.parent.tag == "Cop")
            {
                money.gameObject.SetActive(true);
                money.text = "$"+copFine;
                currentFine += copFine;
                fineText.text = "$" + currentFine;
                infectAI.SubNoMask();
                money.rectTransform.DOScale(.01f, 2);
            }

        }
    }

    

}
