using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{


    public bool playerFound = false;
    private NavMeshAgent[] navAgents;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        RaycastHit hit;

        Vector3 p1 = transform.position;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, 1, transform.forward, out hit, 10))
        {
            distanceToObstacle = hit.distance;
        }
        
        if(playerFound)
        {
            agent.destination = GameObject.FindWithTag("Player").transform.position;
        }

    }
}
