using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpawner : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] GameObject[] Prefabs;
    [SerializeField] int numberOfAI;
    [SerializeField] InfectAI infectAI;
    private void Start()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoints");

        for (int i = 0; i < numberOfAI; i++)
        {
            int rand = Random.Range(0, wayPoints.Length);
            GameObject obj = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], wayPoints[rand].transform.position, Quaternion.identity);
            obj.gameObject.transform.parent = this.gameObject.transform;

            var ai = obj.GetComponent<AI>();
            ai.GetComponent<NavMeshAgent>().speed = Random.Range(1.5f, 2.5f);
            ai.wayPoints = wayPoints;
            infectAI.Ai.Add(ai.gameObject);
            if(Random.value > .5f)
            {
                ai.reverse = true;
            }
            else
            {
                ai.reverse = false;
            }

            if (ai.reverse)
            {
                ai.rNum = rand;
            }
            else
            {
                ai.num = rand;
            }
        }
    }
   
}
