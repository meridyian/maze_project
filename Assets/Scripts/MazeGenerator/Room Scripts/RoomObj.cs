using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;


public class RoomObj : MonoBehaviour
{
    [SerializeField] public List<Transform> roomWalls;
    
    public List<Transform> doorLocations;
    public GameObject doorPrefab;
    
    private int spawnDelay = 3;
    // if this script is used for maze generation spawn doors, if not don't
    public bool isGenerator = true;
    public bool doorsSpawned;
    
    //set room colors
    public Color floorColor;
    public List<MazeCell> FloorList = new List<MazeCell>();
    
    //set id for rooms to match with keys
    public int roomId;



    private void Start()
    {
        StartCoroutine(SpawnDoors());
    }

    

    public void Awake()
    {
        // store walls of the rooms since they will be changed with doors 
        roomWalls = new List<Transform>();
        int iter = gameObject.transform.childCount;

        for (int i = 0; i < iter; i++)
        {
            roomWalls.Add(gameObject.transform.GetChild(i));
        }
        
    }

    public void OnCollisionEnter(Collision other)
    {
        // Change the color of the cells to have better view of different sized rooms on minimap

        if (other.gameObject.CompareTag("Floor"))
        {
            var cell = other.transform.GetComponentInParent<MazeCell>();
            FloorList.Add(cell);
        }


        if (other.gameObject.CompareTag("Wall"))
        {
            other.gameObject.SetActive(false);
            transform.GetComponent<BoxCollider>().isTrigger = true;
        }
    }


    // since they can be used as passages
    // spawn doors at places where room walls are collided with maze walls
    // since you reach RoomObj script dont run spawn doors if you are not using it to generate maze
    public IEnumerator SpawnDoors()
    {
        if (!isGenerator) yield break;
        yield return new WaitForSeconds(spawnDelay);
        int transformLength = roomWalls.Count;
        for (int i = 0; i < transformLength; i++)
        {
            roomWalls[i].gameObject.SetActive(false);
            Instantiate(doorPrefab, roomWalls[i].position, roomWalls[i].rotation, GetComponent<Transform>());
            doorLocations.Add(doorPrefab.GetComponentInParent<Transform>());
        }

        yield return new WaitForSeconds(2);
        transform.parent.GetComponent<Room>().canOpenCanvas = true;

    }

    public void SetRandomColor()
    {
        floorColor = Random.ColorHSV();
        /*System.Random rnd = new System.Random();
        int randIndex = rnd.Next(floorColorArray.Length);
        floorColor = floorColorArray[randIndex];
        */

    }

    public void SetFloorColor()
    {
        foreach (var cell in FloorList)
        {
            var renderer = cell.GetComponentInChildren<Renderer>();
            renderer.material.color = floorColor;
        }
    }


}