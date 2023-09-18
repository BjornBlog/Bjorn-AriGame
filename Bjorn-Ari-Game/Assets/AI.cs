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
        if(playerFound)
        {
            agent.destination = GameObject.FindWithTag("Player").transform.position;
        }
    }
}
