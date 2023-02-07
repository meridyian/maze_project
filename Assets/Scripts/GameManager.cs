using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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


    
    void Start()
    {
        BeginGame();
        
    }


    private void Update()
    {
        if(mazeInstance.isFinished)
            player.SetActive(true);
    }

    public void BeginGame()
    {
        
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
        roomInstance = Instantiate(roomPrefab) as Room;
        player = Instantiate(player, mazeInstance.startingCell.transform.position, Quaternion.identity);
        player.SetActive(false);
    }

    
    

}
