using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDrop : MonoBehaviour
{
    public string RaycastReturn;
    private GameObject FoundObject;
    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private Transform objectGrabPointTransform;

    [SerializeField]
    private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                float pickupDistance = 4f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance))
                {
                    RaycastReturn = raycastHit.collider.gameObject.name;
                    FoundObject = GameObject.Find(RaycastReturn);
                    Debug.Log(raycastHit.transform);
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(objectGrabbable);
                    }
                    if(FoundObject.tag == "Note")
                    {
                        NoteScript note = FoundObject.GetComponent<NoteScript>();
                        note.Pickup();
                    }
                    if(FoundObject.tag == "Battery")
                    {
                        print("Battery");
                        GameObject LightObj = GameObject.FindGameObjectWithTag("FlashlightBulb");
                        LightScript Light = LightObj.GetComponent<LightScript>();
                        Light.batteryCount ++;
                        Destroy(FoundObject);
                    }
                }
            } 
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
