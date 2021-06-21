using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}