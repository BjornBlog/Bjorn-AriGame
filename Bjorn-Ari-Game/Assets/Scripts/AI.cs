using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class AI : MonoBehaviour
{ 
    [SerializeField]
    private GameObject thc6;
    public float maxViewRange = 40f;
    Vector3 playerDirection;
    RaycastHit hit;
    public GameObject player1;
    private FirstPersonController playerScript;
    public GameObject enemy;
    private int playerNoise = 0;
    bool isPatroling = false;
    public bool playerSeen = false;
    private bool foundSound = false;
    // public float distanceX;
    // public float distanceY;
    // public float distanceZ;
    public float sonicDistance = 200f;
    public bool playerFound = false;
    private NavMeshAgent[] navAgents;
    private NavMeshAgent agent;
    void Start()
    {
        playerScript = player1.GetComponent<FirstPersonController>();
        StartCoroutine(Screach());
        agent = GetComponent<NavMeshAgent>();
    }
    private IEnumerator Screach()
    {
        while(!playerFound)
        {
            yield return new WaitForSeconds(Random.Range(15, 45));
            print("sceram");
            enemy.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(15);
        }
        isPatroling = false;
    }
    private IEnumerator Patrol()
    {
        yield return new WaitForSeconds(Random.Range(15, 45));
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
        print("sound is " +playerNoise);
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
            if(!foundSound)
            {
                enemy.GetComponent<AudioSource>().Stop();
                thc6.GetComponent<AudioSource>().Play();
                foundSound = true;
            }
        }
        else
        {
            if(!isPatroling)
            {
                StartCoroutine(Patrol());
                StartCoroutine(Screach());
                isPatroling = true;
                foundSound = false;
            }
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
