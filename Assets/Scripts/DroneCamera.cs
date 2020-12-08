using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamera : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    private float velocity;
    [SerializeField] Vector2 min;
    [SerializeField] Vector2 max;
    [SerializeField] GameObject child;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(h !=0 && v != 0) { return; }

        transform.Translate(h * 5 * Time.deltaTime, 0, v * 5 * Time.deltaTime, Space.World);
        child.transform.localEulerAngles = new Vector3(-5 * v, -5 * h, 0);
        UPDown();
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
