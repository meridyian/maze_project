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

    public GameObject saveCanvas;
    //public GameTimer gT;

    
    void Start()
    {
        BeginGame();
    }

    
    
    
    private void Update()
    {
        // spawn the player at starting cell and set the timer when maze is finished
        
        if (mazeInstance.roomHolderObject.GetComponent<Room>().canOpenCanvas)
        {
            saveCanvas.SetActive(true);
            
        }
        
            
            
    }

    public void BeginGame()
    {
        
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
        //roomInstance = Instantiate(roomPrefab, mazeInstance.transform) as Room;
        //player = Instantiate(player, mazeInstance.startingCell.transform.position, Quaternion.identity);
        //player.SetActive(false);
    }

    
}
