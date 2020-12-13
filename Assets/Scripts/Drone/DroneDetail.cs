using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DroneDetail : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text sliderText;
    [SerializeField] float maxDistance;

  
    void Update()
    {
        RaycastHit info;
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray,out info ,1000))
        {
            slider.value = info.distance/maxDistance;
            sliderText.text = (int)info.distance + " M";
        }
    }
}
