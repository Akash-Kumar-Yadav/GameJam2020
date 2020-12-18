using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Mover : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
  
    Vector3 currentPosition;

    [SerializeField] float timer;
    [SerializeField] int maxTime = 3;
    [SerializeField] UIHealing uIHealing;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPosition = transform.position;
       
    }
   
    private void Update()
    {
        if (GameOverScript.b_gameOver) { return; }
        if (target == null)
        {
            if (transform.position != currentPosition)
            {
                agent.SetDestination(currentPosition);
            }
            return;
        }
       
        agent.SetDestination(target.position);

        if (Vector3.Distance(transform.position, target.position) < 2)
        {
            timer += Time.deltaTime;
            uIHealing.Healing(timer, maxTime,target.gameObject.tag);
            if (timer > maxTime)
            {
                target.GetComponent<SelectAI>().CanMove();
                target.transform.tag = "AI";
                target = null;
                timer = 0;              
            }
        }
    }
   
}
