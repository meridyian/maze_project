using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AgentScript : MonoBehaviour
{
    // navmesh components
    public NavMeshAgent navMeshAgent;
    public LayerMask Player;
    
    // check if player is in defined range
    public float sightRange;
    public bool playerInSightRange;
    

    public void Awake()
    {
        playerInSightRange = false;
    }
    

    public void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        if (playerInSightRange) 
            FollowPlayer();
        
    }

    public void FollowPlayer()
    {
        // since there is no player spawned on start, reach to singleton
        navMeshAgent.SetDestination(TestPlayerMovement.instance.gameObject.transform.position);
        
    }

    
}
