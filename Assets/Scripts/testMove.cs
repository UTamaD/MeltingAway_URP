using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testMove : MonoBehaviour
{
    public Transform destination;

    
    private NavMeshAgent agent;

    void Start()
    {
        if(destination == null)
        {
            Destroy(gameObject);
        }
        else
        {
            agent = GetComponent<NavMeshAgent>();
            
            agent.Warp(gameObject.GetComponent<Transform>().position);
            agent.SetDestination(destination.position);
        }
        
    }

    void Update()
    {

        agent.SetDestination(destination.position);
        
        if(destination != null)
        {
            // Check if the obstacle has reached the destination
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
            {
                Destroy(gameObject); // Destroy the obstacle if it reaches the destination
            }
        }
        else
        {
            Destroy(gameObject);
        }
     

        
    }

}

