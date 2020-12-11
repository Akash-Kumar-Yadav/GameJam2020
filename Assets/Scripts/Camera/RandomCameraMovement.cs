
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 newPos;
    [SerializeField] Quaternion newRot;
   
    [SerializeField] Vector2 min;
    [SerializeField] Vector2 max;
    [SerializeField] float lerpSpeed;

    private void Start()
    {
        newPos = transform.position;
        newRot = transform.rotation;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPos, lerpSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, lerpSpeed);

        if (Vector3.Distance(transform.position, newPos) < 1)
        {
            GetNewPos();
        }
    }

    private void GetNewPos()
    {
        var x = Random.Range(min.x, max.x);
        var y = Random.Range(min.y, max.y);

       // newRot = Quaternion.Euler(0, Random.Range(1, 5), 0);
        newPos = new Vector3(x, 15, y);
    }
}
