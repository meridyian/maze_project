using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // for maze prefab (parent object)
    public Maze mazePrefab;
    public IntVector2 size;
    // to be able to hold created instance
    private Maze mazeInstance;
    public Room roomPrefab;
    private Room roomInstance;



    void Start()
    {
        BeginGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        // you need to assign its type as as 
        mazeInstance = Instantiate(mazePrefab) as Maze;
        StartCoroutine(mazeInstance.Generate());
        roomInstance = Instantiate(roomPrefab) as Room;
        StartCoroutine(roomInstance.SpawnRoom());
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
    

}
