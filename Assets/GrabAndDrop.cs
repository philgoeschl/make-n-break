using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject grabbedObject;
    float grabbedObjectSize;

    GameObject GetRaycastHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if(Physics.Linecast(position,target, out raycastHit))
        { 
            return raycastHit.collider.gameObject;
        }
        return null;
    }

    void TryGrabObject(GameObject grabObject)
    {
        if(grabObject == null || !CanGrab(grabObject))
            return;
        grabbedObject = grabObject;
        grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
    }

    bool CanGrab(GameObject candidate)
    {
        return candidate.GetComponent<Rigidbody>() != null;
    }

    void DropGrabObject()
    {
        if (grabbedObject == null)
            return;
        if(grabbedObject.GetComponent<Rigidbody>() != null)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        grabbedObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Print name of GameObject which is in distance of up to 20 units
        Debug.Log(GetRaycastHoverObject(20));

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(grabbedObject == null)
            {
                TryGrabObject(GetRaycastHoverObject(100));
            } else
            {
                DropGrabObject();
            }
        }
        if (grabbedObject != null)
        {
            // Grab object direct in front of the camera
            //Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            // Grab Object more away from the camera!
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * 10;
            grabbedObject.transform.position = newPosition;
        }
    }
}
