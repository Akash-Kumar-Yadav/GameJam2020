﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTurning : MonoBehaviour
{
    [SerializeField,Range(1,5)] float sensitivity = 2;
    float mouseX;
    void Update()
    {
        if (GameOverScript.b_gameOver) { return; }

        if (Input.GetMouseButton(0))
        {
            mouseX += sensitivity * Input.GetAxis("Mouse X");
            transform.rotation = Quaternion.Euler(0, mouseX, 0);
        }
       
    }


}
