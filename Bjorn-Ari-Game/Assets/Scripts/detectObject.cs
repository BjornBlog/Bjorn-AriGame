using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class detectObject : MonoBehaviour
{
    static int count = 0;

    int count2 = 0;

    int score = 0;

    [SerializeField]
    GameObject Sputnik1;

    [SerializeField]
    GameObject Sputnik2;

    [SerializeField]
    GameObject Sputnik3;

    [SerializeField]
    GameObject Sputnik4;

    [SerializeField]
    GameObject Sputnik5;
    

    void Start()
    {
        count = 0;
        count2 = 0;
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ob1")
        {
            count += 1;
            print(count);
            Destroy(collision.gameObject);
            if (count == 1)
            {
                Destroy(gameObject);
                // Sputnik4.GetComponent<AudioSource>().Play();
                GameObject car = Instantiate(Sputnik4, transform.position, Quaternion.identity);
                car.GetComponent<AudioSource>().Play();
            }
            if (count == 2)
            {
                Destroy(gameObject);
                Sputnik3.GetComponent<AudioSource>().Play();
                Instantiate(Sputnik3, transform.position, Quaternion.identity);
            }
            if (count == 3)
            {
                Sputnik2.GetComponent<AudioSource>().Play();
                Destroy(gameObject);
                Instantiate(Sputnik2, transform.position, Quaternion.identity);
            }
            if (count == 4)
            {
                Destroy(gameObject);
                Sputnik1.GetComponent<AudioSource>().Play();
                Instantiate(Sputnik1, transform.position, Quaternion.identity);
            }
            if (count == 0)
            {
                Destroy(gameObject);
                Instantiate(Sputnik5, transform.position, Quaternion.identity);
            }
        }

        if (collision.gameObject.tag == "Ob2")
        {
            count2 += 1;
            Destroy(collision.gameObject);
            if (count2 == 1)
            {

            }
        }

        if (count == 4 && count2 == 1)
        {
            Application.LoadLevel("Win");
        }


        // if (collision.gameObject.tag == "Ob3")
        // {
        //     count += 1;
        // }

        // if (collision.gameObject.tag == "Ob4")
        // {
            
        // }

        // if (collision.gameObject.tag == "Ob5")
        // {
            
        // }
    }
}
