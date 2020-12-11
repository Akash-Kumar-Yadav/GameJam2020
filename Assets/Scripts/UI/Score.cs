using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text doctext;
    [SerializeField] Text coptext;

    
    int doc;
    int cop;

    private void Start()
    {
        doctext.text = "Doctors: " + doc;
        coptext.text = "Cops: " + cop;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Doc"))
        {
            doc++;
            doctext.text = "Doctors: " + doc;
        } 
        if (other.gameObject.CompareTag("Cop"))
        {
            cop++;
            coptext.text = "Cops: " + cop;
        }
        
    }

  
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Doc"))
        {
            doc--;
            doctext.text = "Doctors: " + doc;
        }
        if (other.gameObject.CompareTag("Cop"))
        {
            cop--;
            coptext.text = "Cops: " + cop;
        }
    }
}
