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
    public GameTimer gt;
    //public Text gameTimerText;
    public Maze maze;
    public Canvas canvas;
    public GameObject panel;
    public bool isThereData = false;
    public static TestManagerScript testinstance;
    
    
    // PS: materyalleri ayarlayabilir misin bak
    
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
        
            // start at time0
            //gt.gameTimer = 0;
            //player.transform.position = maze.startingCell.transform.position;
        }

        else
        {
            
            panel.SetActive(true);
        }

    }

    /*public void RestartGame()
    {

        panel.SetActive(false);
        // spawn at starting cell as if it is a new gamexs
        //PlayerMovement.instance.vec3 = maze.startingCell.transform.position.ToString();
        
        
    }
    */

    public void ReloadGame()
    {
        panel.SetActive(false);
        Instantiate(player,player.GetComponent<PlayerMovement>().playerReload, Quaternion.identity);
        gt.gameObject.GetComponent<GameTimer>().enabled = true;
        
    }

    public void GameSaver()
    {
        SaveSystem.SavePlayer(PlayerMovement.instance.vec3 , gt.timerString);
    }

    private void OnApplicationQuit()
    {
        GameSaver();
    }
}
