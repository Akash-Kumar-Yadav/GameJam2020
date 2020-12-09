using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamera : MonoBehaviour
{
     [SerializeField] int droneSpeed = 5;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    private float velocity;
    [SerializeField] Vector2 min;
    [SerializeField] Vector2 max;
    [SerializeField] GameObject child;

   

    private void Update()
    {
        Movement();
        ClampPostion();
        LocalRotation();
        UPDown();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * droneSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * droneSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * droneSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * droneSpeed * Time.deltaTime, Space.World);
        }
    }

    private void ClampPostion()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -33f, 33f);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -30f, 30f);
        transform.position = clampedPosition;
    }

    private void LocalRotation()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        child.transform.localEulerAngles = new Vector3(-5 * v, -5 * h, 0);
    }

    private void UPDown()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float newPos = Mathf.SmoothDamp(transform.position.y, 25, ref velocity, moveSpeed);
            transform.position = new Vector3(transform.position.x, newPos, transform.position.z);

        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            float newPos = Mathf.SmoothDamp(transform.position.y, 12, ref velocity, moveSpeed);
            transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
        }
    }
}
