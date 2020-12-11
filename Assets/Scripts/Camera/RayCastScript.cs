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

    [SerializeField] GameObject UI;
    
    int numberOfCop = 0;
    int numberOfNurse = 0;
    float timer;
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
                timer += Time.deltaTime;
                if (timer > .5f)
                {
                    target = hit.transform;
                    SettingUIPos();
                    CheckingForTarget();
                    timer = 0;
                }
                
            }
            else
            {
                timer = 0;
                target = null;
                UI.SetActive(false);
            }

        }
       

    }

    private void SettingUIPos()
    {
        UI.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 2, target.transform.position.z);
        UI.SetActive(true);
    }

    private void CheckingForTarget()
    {
        if (target != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                UI.SetActive(false);
                target.GetComponent<SelectAI>().StopMove();

                ResetNumberOfCop();

                cop[numberOfCop].GetComponent<Mover>().target = target;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                UI.SetActive(false);
                target.GetComponent<SelectAI>().StopMove();
                ResetNumberOfNurse();
                nurse[numberOfCop].GetComponent<Mover>().target = target;
            }
        }
    }

    private void ResetNumberOfNurse()
    {
        numberOfNurse++;
        if (numberOfNurse > nurse.Length)
        {
            numberOfNurse = 0;
        }
    }

    private void ResetNumberOfCop()
    {
        numberOfCop++;
        if (numberOfCop > cop.Length)
        {
            numberOfCop = 0;
        }
    }

}
