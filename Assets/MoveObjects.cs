using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{

    private RaycastHit hit;
    private GameObject pickedUpObject = null;
    public float distance = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            
            // check if raycast hits a collider of a gameobject
            if (hit.collider)
            {
                
                // pick up gameobject when pressing Return Key
                if (pickedUpObject == null && Input.GetKeyDown(KeyCode.Return))
                {
                    pickedUpObject = hit.collider.gameObject;
                    hit.collider.enabled = false;
                }

               if (pickedUpObject)
                {
                    hit.collider.gameObject.transform.parent = transform;
                    // gameobject is moved into the direction of the camera with an distance of 10 from the origin
                    hit.collider.gameObject.transform.position = transform.position + new Vector3(0, 0, distance);


                }
                


            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pickedUpObject.transform.SetParent(null);
                //pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
                hit.collider.enabled = true;
            }
        }

      



        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider)
                {
                    pickedUpObject = hit.collider.gameObject;
                    hit.collider.gameObject.transform.parent = transform;
                    hit.collider.gameObject.transform.position = transform.position - transform.forward;
                }
            }
        }*/
    }
}
