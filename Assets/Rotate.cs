using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rotate : MonoBehaviour
{
    private GameObject selectedObject;
    private GameObject resetObject;

    //private Image timer; //Timer UI Element
    private float selectTimer; //Timer for selecting elements

    public float waitSeconds = 5.0f; //Wait time until object selection

    // Start is called before the first frame update
    GameObject GetRaycastHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit))
        {
            return raycastHit.collider.gameObject;
        }
        return null;
    }

    void RotateObject(GameObject rotateObject)
    {
        if (rotateObject == null)
            return;

        rotateObject.transform.Rotate(0, 0, 90);

    }

    void Start()
    {
        selectTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ROTATE SCRIPT"+GetRaycastHoverObject(100));
        if (GetRaycastHoverObject(100) != null)
        {
            if (selectedObject == GetRaycastHoverObject(100) && selectedObject.gameObject.tag == "Cube")
            {
                if (selectTimer < waitSeconds)
                {
                    //timer.fillAmount = selectTimer / waitSeconds;
                    //timer.enabled = true;
                    selectTimer += Time.deltaTime;
                    Debug.Log(selectTimer);
                }
                else if (selectTimer > waitSeconds)
                {
                    //timer.enabled = false;
                    Debug.Log("ROTATED GAMEOBJECT");
                    RotateObject(selectedObject);
                    selectedObject = null;

                }
            }
            else
            {
                selectedObject = GetRaycastHoverObject(100);
                selectTimer = 0;
            }
        }
    }
}
