using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float turnSpeed = 50f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }
}
