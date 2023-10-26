using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class detectObject : MonoBehaviour
{
    int count = 0;

    int count2 = 0;

    int score = 0;
    void Start()
    {
        
    }

    void Update()
    {
        print(score);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ob1")
        {
            print("doable");
            count += 1;
            score += 10;
            Destroy(collision.gameObject);
            print(count);
        }

        if (count == 6)
        {
            Application.LoadLevel("Death");
        }

         if (collision.gameObject.tag == "Ob2")
        {
            count2 += 1;
            score += 15;
            Destroy(collision.gameObject);
            print(count2);
        }
    }
}
