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
    public static AgentScript agentinstance;
    
    public string agentPos;
    public Vector3 agentReload;
    public bool reloadAgent=false;
    

    public void Awake()
    {
        if (agentinstance != null) return;
        agentinstance = this;
        
        playerInSightRange = false;
    }

    public void Start()
    {
        LoadAgent();
        
    }
    
    public void LoadAgent()
    {
        if (reloadAgent)
        {
            PlayerData data = SaveSystem.LoadGame();
            agentPos = data.agentposition;
            string[] agentposarr = agentPos.Split(new char[] { ',',' ',')', '(','"'});
            agentReload = new Vector3(float.Parse(agentposarr[1]), float.Parse(agentposarr[3]), float.Parse(agentposarr[5]));
            gameObject.transform.position = agentReload;
        }
            
    }

    public void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        if (playerInSightRange) 
            FollowPlayer();
        agentPos = transform.position.ToString();
        
    }

    public void FollowPlayer()
    {
        // since there is no player spawned on start, reach to singleton
        navMeshAgent.SetDestination(TestPlayerMovement.instance.gameObject.transform.position);
        
    }

    
}
