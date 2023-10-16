using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    private Transform objectGrabPointTransform;
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform )
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
         objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpspeed = 10f;
            Vector3 newPosition = Vector3.Lerp(objectGrabPointTransform.position, objectGrabPointTransform.position, Time.deltaTime * lerpspeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
