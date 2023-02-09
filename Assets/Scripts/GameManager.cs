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

    public GameTimer gT;

    
    void Start()
    {
        BeginGame();
        Debug.Log(Application.persistentDataPath);
        
    }

    
    public void Saver()
    {
        SaveSystem.SavePlayer(PlayerMovement.instance.vec3,gT.timerString);
    }

    private void Update()
    {
        if (mazeInstance.isFinished)
        {
            player.SetActive(true);
            gameTimer.gameObject.GetComponent<GameTimer>().enabled = true;
        }
            
            
    }

    public void BeginGame()
    {
        
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
        roomInstance = Instantiate(roomPrefab) as Room;
        player = Instantiate(player, mazeInstance.startingCell.transform.position, Quaternion.identity);
        player.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        Saver();
    }
}
