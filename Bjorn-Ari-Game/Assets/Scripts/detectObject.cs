using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class detectObject : MonoBehaviour
{
    int count = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ob1")
        {
            print("doable");
            count += 1;
            Destroy(collision.gameObject);
            print(count);
        }

        if (count == 7)
        {
            Application.LoadLevel("Death");
        }
    }
}
