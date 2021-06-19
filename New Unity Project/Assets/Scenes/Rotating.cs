using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public Transform cube;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // GET TOUCH 0
            Touch touch0 = Input.GetTouch(0);

            // APPLY ROTATION
            if (touch0.phase == TouchPhase.Moved)
            {
                cube.transform.Rotate(0f, touch0.deltaPosition.x, 0f);
            }

        }
    }
}
