using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotation : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public bool isRight = false;

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

    }
}
