using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class AI : MonoBehaviour
{
    private GameObject pauseObject;
    private PauseScreen pauseSystem; 
    public GameObject thc6;
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
    private TimeCycle time;
    void Awake()
    {
        GameObject TimeObject = GameObject.FindGameObjectWithTag("TimeControl");
        time = TimeObject.GetComponent<TimeCycle>();
        pauseObject = GameObject.FindGameObjectWithTag ("Pause");
        pauseSystem = pauseObject.GetComponent<PauseScreen>();
    }
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
        while(isPatroling)
        {
            Vector3 Destination = RandomNavmeshLocation(Random.Range(20, 50))
            yield return new WaitForSeconds(Random.Range(15, 30));
        }
        
    }
    void Update()
    {
        if(time.sunsetTime >= time.currentTime.TimeOfDay &&  time.currentTime.TimeOfDay >= time.sunriseTime)
        {
            DestroyEnemy();
        }
        if (pauseSystem.GetIsPaused())
        { 
            return; 
        }
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
    public Vector3 RandomNavmeshLocation(float radius) 
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) 
        {
            finalPosition = hit.position;            
        }
        return finalPosition;
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
    public void DestroyEnemy()
    {
        Destroy(enemy);
    }
}
