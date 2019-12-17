using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            float x = 5 * Input.GetAxis("Mouse X");
            float y = 5 * Input.GetAxis("Mouse Y");
            this.transform.Rotate(y, x, 0);
        }
    }
}
