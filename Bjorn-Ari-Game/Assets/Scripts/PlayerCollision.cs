using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public bool playerDead = false;
    public int playerHealth = 100;
    public Slider healthBar;
    private LightScript Flashlight;
    private GameObject HandHeldLight;
    // Start is called before the first frame update
    void Start()
    {
        HandHeldLight = GameObject.FindGameObjectWithTag ("FlashlightBulb");
        Flashlight = HandHeldLight.GetComponent<LightScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthBar.value = playerHealth;
        if(playerDead)
        {
            print("player Dead");
        }
        else if(playerHealth <= 0)
        {
            playerHealth = 0;
            playerDead = true;
            Application.LoadLevel("Death");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        print("Collide");
        if(other.gameObject.tag == "Enemy")
        {
            playerHealth = playerHealth - 100;
            print(playerHealth);
        }
        if(other.gameObject.tag == "Battery")
        {
            Destroy(other.gameObject);
            Flashlight.batteryCount = Flashlight.batteryCount + 1;
        }
    }
}
