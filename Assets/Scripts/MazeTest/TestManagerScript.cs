using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class TestManagerScript : MonoBehaviour
{
    public GameObject player;
    public TestTimer gt;
    //public Text gameTimerText;
    public Maze maze;
    public Canvas canvas;
    public GameObject panel;
    public AgentScript agent;
    public GameObject keys;
    
    // check if this is the first play
    public bool isThereData = false;
    public static TestManagerScript testinstance;
    
    private void Awake()
    {
        // so that you can handle it in savedata and playerscripts
        
        if (testinstance != null) return;
        testinstance = this;

    }

    void Start()
    {
        // check if it is your first game
        if (!isThereData)
        {
            panel.SetActive(false);
            Instantiate(player,maze.startingCell.transform.position, Quaternion.identity);
            gt.enabled = true;
            
        }

        // if this is the first game decide what to do on panel
        
        else
        {
            
            panel.SetActive(true);
            gt.enabled = false;
        }

    }

    public void RestartGame()
    {
        // start a completely new game spawned at starting cell, control LoadPlayer method
        
        panel.SetActive(false);
        GameObject instplayer = Instantiate(player,maze.startingCell.transform.position, Quaternion.identity);
        // start a new game dont call LoadGame
        instplayer.GetComponent<TestPlayerMovement>().playerIsThere = false;
        FindObjectOfType<AgentScript>().reloadAgent = false;
        gt.gameTimer = 0;
        gt.enabled = true;
        

    }
    

    public void ReloadGame()
    {
        // if reload button is pressed instantiate player at where you left and load last game time and removed ceilings
        // if reload button is pressed agent should be spawned at last position
        if (agent.transform.position != AgentScript.agentinstance.agentReload)
            agent.transform.position = AgentScript.agentinstance.agentReload;
        else
        {
            return;
        }
        panel.SetActive(false);
        GameObject reloadplayer = Instantiate(player,player.GetComponent<TestPlayerMovement>().playerReload, Quaternion.identity);
        FindObjectOfType<AgentScript>().reloadAgent = true;
        reloadplayer.GetComponent<TestPlayerMovement>().playerIsThere = true;
        gt.enabled = true;
       
        
    }

    // save the game
    
    public void GameSaver()
    {
        // Add agent position
        //SaveSystem.SaveGame(TestPlayerMovement.instance.vec3 , gt.timerString, TestPlayerMovement.instance.removedceilings,agent.agentPos);
    }

    

    private void OnApplicationQuit()
    {
        GameSaver();
    }
    
}
