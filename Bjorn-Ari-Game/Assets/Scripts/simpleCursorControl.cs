using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCursorControl : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
