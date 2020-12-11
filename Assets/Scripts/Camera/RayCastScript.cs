using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RayCastScript : MonoBehaviour
{
    [SerializeField] Camera camera;
    RaycastHit hit;
    [SerializeField] Transform[] cop;
    [SerializeField] Transform[] nurse;

    [SerializeField] Transform target;

    [SerializeField] GameObject UI;
    [SerializeField] TMP_Text UIText;
    
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
            if (hit.collider.CompareTag("NoMask") || hit.collider.CompareTag("Infected"))
            {
                timer += Time.deltaTime;
                if (timer > .5f)
                {
                    target = hit.transform;
                    SettingUIPos();                   
                    timer = 0;
                }               
            }
            else
            {
                timer = 0;
                target = null;
                UI.SetActive(false);
            }
            CheckingForTarget();
        }
    }
    private void SettingUIPos()
    {
        UIText.text = target.gameObject.tag;
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
        if (numberOfNurse > nurse.Length-1)
        {
            numberOfNurse = 0;
        }
    }

    private void ResetNumberOfCop()
    {
        numberOfCop++;
        if (numberOfCop > cop.Length-1)
        {
            numberOfCop = 0;
        }
    }

}
