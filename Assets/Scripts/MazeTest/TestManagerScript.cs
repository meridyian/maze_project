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
        player.transform.position = maze.startingCell.transform.position;
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
        // spawn at starting cell as if it is a new game
        TestPlayerMovement.instance.vec3 = maze.startingCell.transform.position.ToString();
        


    }
    

    public void ReloadGame()
    {
        panel.SetActive(false);
        Instantiate(player,player.GetComponent<TestPlayerMovement>().playerReload, Quaternion.identity);
        gt.enabled = true;
        // setactive false for each element in removed list
        foreach (var ceilings in TestPlayerMovement.instance.removedceilings)
        {
            maze.transform.GetChild(0).Find(ceilings).gameObject.SetActive(false);
        }
        //maze.transform.Find()

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
