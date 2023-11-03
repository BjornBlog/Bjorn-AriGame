using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDrop : MonoBehaviour
{
    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private Transform objectGrabPointTransform;

    [SerializeField]
    private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;
    public string RaycastReturn;
    //private GameObject FoundObject;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(objectGrabbable == null)
            {
                float pickupDistance = 4f;
                if(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance))
                {
                    
                    Debug.Log(raycastHit.transform);
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(objectGrabbable);
                    }
                    if (raycastHit.collider != null)
                    {
                        RaycastReturn = raycastHit.collider.gameObject.name;
                        GameObject FoundObject = GameObject.Find(RaycastReturn);
                        if(FoundObject.tag == "Note")
                        {
                            NoteScript noteStuff = FoundObject.GetComponent<NoteScript>();
                            noteStuff.Pickup();
                        }
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
