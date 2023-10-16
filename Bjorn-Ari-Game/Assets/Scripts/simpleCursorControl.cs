using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCursorControl : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
