using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollowing : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    bool lockedCurser = true;
    void Start()
    {
       Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float InputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float InputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalRotation -= InputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 40f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        // player.Rotate(Vector3.up * inputX;)
    }
}
