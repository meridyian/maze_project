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
    
    
    
    
    // PS: materyalleri ayarlayabilir misin bak

    void Start()
    {
        panel.SetActive(true);
        
        //Instantiate(player, Vector3.zero, Quaternion.identity);
    }

    public void RestartGame()
    {

        panel.SetActive(false);
        // spawn at starting cell as if it is a new gamexs
        Instantiate(player,maze.startingCell.transform.position, Quaternion.identity);
        gt.gameObject.GetComponent<GameTimer>().enabled = true;
        // start at time0
        gt.gameTimer = 0;
    }

    public void ReloadGame()
    {
        panel.SetActive(false);
        /*Vector3 newpos;
        newpos.x = PlayerMovement.instance.vec3[0];
        newpos.y = PlayerMovement.instance.vec3[1];
        newpos.z = PlayerMovement.instance.vec3[2];
        */
        Instantiate(player,player.transform.position, Quaternion.identity);
        gt.gameObject.GetComponent<GameTimer>().enabled = true;
        
    }

    public void GameSaver()
    {
        SaveSystem.SavePlayer(PlayerMovement.instance.vec3, gt.timerString);
    }

    private void OnApplicationQuit()
    {
        GameSaver();
    }
}
