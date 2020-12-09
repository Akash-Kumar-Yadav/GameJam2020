using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] int num = 0;
    [SerializeField] float speed;

    private void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position, wayPoints[num].position, speed);
        agent.SetDestination(wayPoints[num].position);
        if (Vector3.Distance(transform.position, wayPoints[num].position) < .3f)
        {     
            num++;
        }
    }

}
