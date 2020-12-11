using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float minpos;
    [SerializeField] float maxpos;

    private void Start()
    {
        slider.maxValue = maxpos;
        slider.minValue = minpos;
    }
    private void Update()
    {
        slider.value = transform.position.z % maxpos;
        float h = Input.GetAxis("Horizontal") * 20 * Time.deltaTime;
        transform.Translate(0, 0, h);
    }
}
