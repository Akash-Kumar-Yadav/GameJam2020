using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    [SerializeField] Camera camera;
    RaycastHit hit;
    [SerializeField] Transform[] cop;
    [SerializeField] Transform[] nurse;

    [SerializeField] Transform target;

   // [SerializeField] GameObject UI;
    
    int numberOfCop = 0;
    int numberOfNurse = 0;
    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("AI"))
            {
                target = hit.transform;
               // UI.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z);
              //  UI.SetActive(true);
            }
            else
            {
                target = null;
            }
          
        }
        if(target != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
               // UI.SetActive(false);
                target.GetComponent<SelectAI>().StopMove();
                numberOfCop++;
                if(numberOfCop > cop.Length)
                {
                    numberOfCop = 0;
                }
                cop[numberOfCop].GetComponent<Mover>().target = target;
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
               // UI.SetActive(false);
                target.GetComponent<SelectAI>().StopMove();
                numberOfNurse++;
                if (numberOfNurse > nurse.Length)
                {
                    numberOfNurse = 0;
                }
                nurse[numberOfCop].GetComponent<Mover>().target = target;
            }
        }
       
    }

   
}
