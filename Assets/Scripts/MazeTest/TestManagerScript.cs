using System;
using System.Collections;
using System.Collections.Generic;
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
    
    public bool isThereData = false;
    public static TestManagerScript testinstance;




    private void Awake()
    {
        if (testinstance != null) return;
        testinstance = this;
        
        
    }

    void Start()
    {
        
        if (!isThereData)
        {
            panel.SetActive(false);
            Instantiate(player,maze.startingCell.transform.position, Quaternion.identity);
            gt.enabled = true;
        
            //start at time0
            
        }

        else
        {
            
            panel.SetActive(true);
            gt.enabled = false;
        }

    }

    public void RestartGame()
    {
        panel.SetActive(false);
        GameObject instplayer = Instantiate(player,maze.startingCell.transform.position, Quaternion.identity);
        instplayer.GetComponent<TestPlayerMovement>().playerIsThere = false;
        gt.gameTimer = 0;
        gt.enabled = true;
        // spawn at starting cell as if it is a new game
        //TestPlayerMovement.instance.vec3 = maze.startingCell.transform.position.ToString();


    }
    

    public void ReloadGame()
    {
        panel.SetActive(false);
        GameObject reloadplayer = Instantiate(player,player.GetComponent<TestPlayerMovement>().playerReload, Quaternion.identity);
        reloadplayer.GetComponent<TestPlayerMovement>().playerIsThere = true;
        gt.enabled = true;
        // setactive false for each element in removed list
        foreach (var ceilings in TestPlayerMovement.instance.removedceilings)
        {
            maze.transform.GetChild(0).Find(ceilings).gameObject.SetActive(false);
        }


    }

    public void GameSaver()
    {
        SaveSystem.SavePlayer(TestPlayerMovement.instance.vec3 , gt.timerString, TestPlayerMovement.instance.removedceilings);
    }

    

    private void OnApplicationQuit()
    {
        GameSaver();
    }
    
}
