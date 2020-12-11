using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectAI : MonoBehaviour
{
    public List<GameObject> Ai = new List<GameObject>();
    [SerializeField] int infect;
    [SerializeField] int noMask;
    [SerializeField] string infectTag = "Infected";
    [SerializeField] string noMaskTag = "NoMask";
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < infect; i++)
        {
            Ai[i].gameObject.tag = infectTag;
        }

        for (int i = infect; i < infect+noMask; i++)
        {
           
            Ai[i].gameObject.tag = noMaskTag;
        }
    }
}
