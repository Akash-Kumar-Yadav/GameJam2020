using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Mover : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Rigidbody rb;
    Vector3 currentPosition;

    [SerializeField] float timer;
    [SerializeField] int maxTime = 3;   

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RB());
    }

    IEnumerator RB()
    {
        yield return new WaitForSeconds(1);
        rb.Sleep();
    }
    private void Update()
    {
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
            if (timer > maxTime)
            {
                target.GetComponent<SelectAI>().CanMove();
                target = null;
                timer = 0;
               
            }
        }
    }
   
}
