using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSound : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] float pitch;
    [SerializeField] float defaultPitch;

    private void Start()
    {
        audio = GetComponent<AudioSource>();       
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float u = Input.GetAxis("UPLift");

        if (Input.GetKey(KeyCode.W))
        {
            audio.pitch = pitch * v;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            audio.pitch = pitch * v;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            audio.pitch = pitch * h;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            audio.pitch = pitch * h;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            audio.pitch = pitch * u;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            audio.pitch = pitch * u;
        }
        else
        {
            audio.pitch = defaultPitch;
        }

    }
}
