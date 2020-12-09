using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Prefabs;
    [SerializeField] float spawnTime;
    [SerializeField] float numberOfCars;
    [SerializeField] PathCreator path;
    int i = 1;
    //void Update()
    //{
    //    if(Time.time > spawnTime)
    //    {
    //        GameObject obj = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], transform.position, Quaternion.identity);
    //        obj.GetComponent<CarAI>().pathCreator = path;
    //        spawnTime = Time.time + spawnTime;
    //    }
    //}

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        GameObject obj = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], transform.position, Quaternion.identity);
        obj.GetComponent<CarAI>().pathCreator = path;
       
        yield return new WaitForSeconds(spawnTime);
        i++;
        if (i < numberOfCars)
        {
            StartCoroutine(Spawner());
        }
    }
}
