using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // for maze prefab (parent object)
    public Maze mazePrefab;
    // to be able to hold created instance
    private Maze mazeInstance;   
    
    public Room roomPrefab;
    private Room roomInstance;

    private RoomWall roomWall;
    public GameObject player;
    private bool spawnroom;
    public Text gameTimer;

    //public GameTimer gT;

    
    void Start()
    {
        BeginGame();
    }

    
    
    
    private void Update()
    {
        // spawn the player at starting cell and set the timer when maze is finished
        
        if (mazeInstance.isFinished)
        {
            // canvası açabilirsin
            Debug.Log("Maze is finished");
            
            //player.SetActive(true);
            //gameTimer.gameObject.GetComponent<GameTimer>().enabled = true;
        }
            
            
    }

    public void BeginGame()
    {
        
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
        roomInstance = Instantiate(roomPrefab, mazeInstance.transform) as Room;
        //player = Instantiate(player, mazeInstance.startingCell.transform.position, Quaternion.identity);
        //player.SetActive(false);
    }

    
}
