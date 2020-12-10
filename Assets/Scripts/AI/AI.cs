using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    public GameObject[] wayPoints;
    public int num = 0;
    public int rNum = 48;
    public bool reverse;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
       
        if (!reverse)
        {
            agent.SetDestination(wayPoints[num].transform.position);
            if (Vector3.Distance(transform.position, wayPoints[num].transform.position) < .8f)
            {
                num++;
                if (num > wayPoints.Length-1)
                {
                    num = 0;    
                }
            }
        }
        else
        {
            agent.SetDestination(wayPoints[rNum].transform.position);
            if (Vector3.Distance(transform.position, wayPoints[rNum].transform.position) < .8f)
            {
                rNum--;
                if (rNum < 0)
                {
                    rNum = 47;
                }
            }
        }
        
    }

}
