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
    private bool spawnroom;
    private RoomWall roomWall;







    void Start()
    {
        BeginGame();

    }



    public void BeginGame()
    {
        // you need to assign its type as as 
        //miniMapcamera.clearFlags = CameraClearFlags.Skybox;
       // miniMapcamera.rect = new Rect(0f, 0f, 1f, 1f);
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
        roomInstance = Instantiate(roomPrefab) as Room;
        //miniMapcamera.clearFlags = CameraClearFlags.Depth;
        //miniMapcamera.rect = new Rect(0f, 0f, 0.5f, 0.5f);
        //StartCoroutine(roomInstance.SpawnRoom());

        

    }

    
    

}
