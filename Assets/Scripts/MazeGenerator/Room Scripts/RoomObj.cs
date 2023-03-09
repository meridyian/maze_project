using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Assets.Scripts.MazeGenerator.Unlockables;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;


public class RoomObj : MonoBehaviour/*,IUnlockable*/
{
    [SerializeField] public List<Transform> roomWalls;
    public List<Transform> doorLocations;
    public GameObject doorPrefab;
    private int spawnDelay = 3;
    public bool isGenerator = true;

    public bool doorsSpawned;
    public Color floorColor;
    public List<MazeCell> FloorList = new List<MazeCell>();
    public int Id { get; set; }
    public List<Unlockable> unlockables = new List<Unlockable>();

    private void Start()
    {
        StartCoroutine(SpawnDoors());
        SetLock();
    }

    public void UnlockDoors()
    { 
        var doors = transform.GetComponentsInChildren<MoveDoor>();
        foreach (var door in doors)
        {
            door.UnlockDoor(); 
        }
    }

    private void SetLock()
    {
        foreach (var unlockable in unlockables)
        {
            unlockable.Lock = this;
        }
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


    public void TryUnlock()
    {
        foreach (var unlockable in unlockables)
        {
            if (!unlockable.IsUnlocked)
            {
                return;
            }
        }
        UnlockDoors();
    }
}