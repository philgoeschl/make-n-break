using System.Collections;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private LineRenderer laserLine;


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        laserLine.SetPosition(0, this.transform.position);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                laserLine.SetPosition(1, hit.point);
            }
        }
        else laserLine.SetPosition(1, transform.forward * 1000);
    }
}
