using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{
    public RoomObj[] roomPrefabs;

    public List<RoomObj> RoomObjectList = new List<RoomObj>();
    private List<Vector3> points = new List<Vector3>();
    
    public Maze maze;
    private MazeCell mazeCell;
    private float maxRoomWidth;

    
    public bool canOpenCanvas { get; set; }
    private RoomWall roomWall;
    public List<float> x = new List<float>();
    
    
    public void Awake()
    {
        SetSize();
        canOpenCanvas = false;
    }

    
    // to find the largest room in prefabs 
    public float SetSize()
    {
        foreach (var item in roomPrefabs)
        {
            float k = item.transform.childCount;

            x.Add(k);
            x = x.OrderBy(k => k).ToList();
            maxRoomWidth = x.Last();
            //minRoomWidth = x.First();
        }
        Debug.Log(maxRoomWidth);
        return maxRoomWidth;
    }

    
    
    public IEnumerator SpawnRoom()
    {
        // spawn rooms in a range so that they will be inside of the maze bounds
        // maxRoomWidth/4f should be equal to length of the biggest room's edge
        // build a while loop to specify number of the rooms that will be spawned
        Debug.Break();
        float roomDistance = maxRoomWidth / 4f + 2f;
        int numGeneratedPoints = 0; //counter for the generated number points

        while (numGeneratedPoints < maze.numberofRoom)
        {
            float x = Random.Range(-maze.mazesize.x * 0.5f + maxRoomWidth/4f, maze.mazesize.x * 0.5f - maxRoomWidth/4f);
            float z = Random.Range(-maze.mazesize.z * 0.5f + maxRoomWidth/4f, maze.mazesize.z * 0.5f - maxRoomWidth/4f);
            
            Vector3 point = new Vector3(Mathf.RoundToInt(x), 0.5f, Mathf.RoundToInt(z));

            if (points.Count == 0)
            {
                points.Add(point);
                numGeneratedPoints++;
                Debug.Log("first room");
                continue;
            }

            bool isValidPoint = true;
            for (int j = 0; j < points.Count; j++)
            {
                //distance between points should always be bigger than hypotenuse of the room
                if ((point - points[j]).sqrMagnitude <= roomDistance * roomDistance)
                {
                    // if the distance is less than the minimum distance, the new point is too close to an existing point
                    isValidPoint = false;
                    break;
                }
            }
            
            // If the new point is valid, add it to the list and increment the number of generated points
            if (isValidPoint)
            {
                points.Add(point);
                numGeneratedPoints++;
            }
        }

        foreach (Vector3 point in points)
        {
            Debug.Log("point : " + point);
        }
        
        
        yield return new WaitForSeconds(1);

        for (int i = 0; i < points.Count; i++)
        {
            // spawn rooms at points
            
            int randomIndex = Random.Range(0, roomPrefabs.Length);
            var go = Instantiate(roomPrefabs[randomIndex], points[i], Quaternion.identity, maze.roomHolderObject.transform);
            //collect room objects in a list to set color
            RoomObjectList.Add(go);
            go.name = roomPrefabs[randomIndex].name + " " +(i+1);
            // give id for keys
            go.roomId = i+1;
            go.SetRandomColor();
            go.SetFloorColor();
        }
        
    }
    

}
