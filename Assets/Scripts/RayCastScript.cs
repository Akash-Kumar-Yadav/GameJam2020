using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    [SerializeField] Camera camera;
    RaycastHit hit;
    
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
                print("----"+hit.collider.gameObject.name);
            }
            else
            {
                print(hit.collider.gameObject.name);
            }
        }
       
    }

   
}
