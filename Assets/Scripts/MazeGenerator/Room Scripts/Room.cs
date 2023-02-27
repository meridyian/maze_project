using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{
    public RoomObj[] roomPrefabs;
    //public float distanceBetweenRooms;
    private List<Vector3> points = new List<Vector3>();
    
    public Maze maze;
    private MazeCell mazeCell;
    private float maxRoomWidth;
    public int roomCount;
    
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
        // spawn rooms şn a range that they will be inside of the maze bounds
        // transformPntExtens should be equal to length of the biggest room's edge

        float roomDistance = maxRoomWidth / 4f + 2f;
        for (int i = 0; i < roomCount; i++)
        {
            
            float x = Random.Range(-maze.mazesize.x * 0.5f + maxRoomWidth/4f, maze.mazesize.x * 0.5f - maxRoomWidth/4f);
            float z = Random.Range(-maze.mazesize.z * 0.5f + maxRoomWidth/4f, maze.mazesize.z * 0.5f - maxRoomWidth/4f);
            
            
            Vector3 point = new Vector3(Mathf.RoundToInt(x), 0.5f, Mathf.RoundToInt(z));

            if (points.Count == 0)
            {
                points.Add(point);
                i++;
                Debug.Log("first room");
                continue;
            }

            for (int j = 0; j < points.Count; j++)
            {
                // distance between points should always be bigger than hypotenuse of the room 

                
                if ((point - points[j]).sqrMagnitude > roomDistance * roomDistance)
                {
                    if (j == points.Count - 1)
                    {
                        points.Add(point);
                        i++;
                    }
                    continue;
                }
                break;
            }
            
        }
        
        yield return new WaitForSeconds(1);

        for (int i = 0; i < points.Count; i++)
        {
            // spawn rooms at points
            
            int randomIndex = Random.Range(0, roomPrefabs.Length);
            var go = Instantiate(roomPrefabs[randomIndex], points[i], Quaternion.identity, maze.roomHolderObject.transform);
            go.name = roomPrefabs[randomIndex].name + " " +(i+1);

            
        }
        

    }
    
    

}
