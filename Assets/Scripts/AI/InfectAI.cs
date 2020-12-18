using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfectAI : MonoBehaviour
{
    public List<GameObject> Ai = new List<GameObject>();

    [SerializeField] int infect;
    [SerializeField] int noMask;
    [SerializeField] string infectTag = "Infected";
    [SerializeField] string noMaskTag = "NoMask";

    [SerializeField] TMP_Text infectedText;
    [SerializeField] TMP_Text NoMaskText;

    public int getInfected
    {
        get
        {
            return infect;
        }
    }
    public int getNoMask
    {
        get
        {
            return noMask;
        }
    }

    IEnumerator Start()
    {
        infectedText.text = "Infected: ..." ;
        NoMaskText.text = "No Mask: ..." ;
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < infect; i++)
        {
            Ai[i].gameObject.tag = infectTag;
        }

        for (int i = infect; i < infect+noMask; i++)
        {
           
            Ai[i].gameObject.tag = noMaskTag;
        }
        infectedText.text = "Infected: " + infect;
        NoMaskText.text = "No Mask: " + noMask;
    }

    private void Update()
    {
        infectedText.text = "Infected: " + infect;
        NoMaskText.text = "No Mask: " + noMask;
    }
    public void SubInfected()
    {
         infect--;
    }
    public void SubNoMask()
    {
         noMask--;
    }
}
