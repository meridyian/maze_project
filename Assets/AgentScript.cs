using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AgentScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public LayerMask Player;
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
        navMeshAgent.SetDestination(TestPlayerMovement.instance.gameObject.transform.position);
        
    }

    
}
