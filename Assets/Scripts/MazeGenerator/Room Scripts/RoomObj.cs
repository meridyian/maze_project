using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class RoomObj : MonoBehaviour
{
    [SerializeField] public List<Transform> roomWalls;
    public List<Transform> doorLocations;
    public GameObject doorPrefab;
    private int spawnDelay = 3;
    public RoomSO roomSo;
    public bool doorsSpawned;
    public Color floorColor;
    public List<MazeCell> FloorList = new List<MazeCell>();


    private void Start()
    {
        StartCoroutine(SpawnDoors());
        //List<Transform> doorLocations = new List<Transform>();
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
            // if(transform.name.StartsWith("Red"))
            //     other.gameObject.GetComponentInChildren<Renderer>().material.color = roomSo.bigRoomColor;
            // if(transform.name.StartsWith("Blue"))
            //     other.gameObject.GetComponentInChildren<Renderer>().material.color = roomSo.smallRoomColor;
        }


        if (other.gameObject.CompareTag("Wall"))
        {
            other.gameObject.SetActive(false);
            transform.GetComponent<BoxCollider>().isTrigger = true;
        }
    }


    // since they can be used as passages
    // spawn doors at places where room walls are collided with maze walls
    public IEnumerator SpawnDoors()
    {
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
        floorColor = new Color
        {
            r = Random.Range(0, 1f),
            g = Random.Range(0, 1f),
            b = Random.Range(0, 1f),
            a = 1
        };
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