using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class AI : MonoBehaviour
{ 
    public float maxViewRange = 40f;
    Vector3 playerDirection;
    RaycastHit hit;
    public GameObject player1;
    private FirstPersonController playerScript;
    public GameObject enemy;
    private int playerNoise = 0;
    public bool playerSeen = false;
    // public float distanceX;
    // public float distanceY;
    // public float distanceZ;
    public float sonicDistance;
    public bool playerFound = false;
    private NavMeshAgent[] navAgents;
    private NavMeshAgent agent;
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag ("Player");
        playerScript = player1.GetComponent<FirstPersonController>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //int layerMask = 1 << 8;
        Vector3 p1 = transform.position;
        Vector3 delta = enemy.transform.position - player1.transform.position;
        // distanceX = delta.x;
        // distanceY = delta.y;
        // distanceZ = delta.z;
        sonicDistance = delta.magnitude;
        // if(Physics.SphereCast(playerScript, 1, transform.forward, out hit, 30))
        // {
        //     visonDistance = hit.distance;
        // }
        // else
        // {
        //     visonDistance = 40;
        // }
        playerNoise = playerScript.noise();
        if(playerSeen)
        {
            float pdX = player1.transform.position.x - enemy.transform.position.x;
            float pdY = player1.transform.position.y - enemy.transform.position.y;
            float pdZ = player1.transform.position.z - enemy.transform.position.z;
            playerDirection = new Vector3(pdX, pdY, pdZ);
            if (Physics.Raycast(enemy.transform.position, playerDirection, out hit, maxViewRange/*, layerMask*/))
            {
                print("Did Hit");
                playerFound = true;
                print("I See You!");
            }
        }
        else if(60 >= sonicDistance && sonicDistance >= -60)
        {
            if(playerNoise == 1)
            {
                playerFound = true;
                print("Very loud");
            }
            else if(30 >= sonicDistance && sonicDistance >= -30)
            {
                if(playerNoise == 2)
                {
                    playerFound = true;  
                    print("Loud");
                }
                else if(15 >= sonicDistance && sonicDistance >= -15)
                {
                    if(playerNoise == 3)
                    {
                        playerFound = true;
                        print("sound");
                    }
                }
            }
        }
        if(playerFound)
        {
            agent.destination = GameObject.FindWithTag("Player").transform.position;
        }
        else
        {
            //Patrol
        }
        playerFound = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        print("GameObject");
        if(other.gameObject.tag == "Player")
        {
            playerSeen = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        print("GameObjectGone");
        if(other.gameObject.tag == "Player")
        {
            playerSeen = false;
        }
    }
}
