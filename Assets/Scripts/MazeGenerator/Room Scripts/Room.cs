using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{
    public RoomObj[] roomPrefabs;
    public float distanceBetweenRooms;
    private List<Vector3> points = new List<Vector3>();
    public GameManager gameManager;
    public Maze maze;
    private MazeCell mazeCell;
    private float maxRoomWidth;
    public int roomCount;
    
    
    private RoomWall roomWall;
    public float transformPntExtens;
    public List<float> x = new List<float>();

    
    public void Awake()
    {
        SetSize();

    }
    
    // to find the largest room in prefabs 
    public float SetSize()
    {
        foreach (var item in roomPrefabs)
        {
            float k = item.transform.localScale.x;

            x.Add(k);
            x = x.OrderBy(k => k).ToList();
            maxRoomWidth = x.Last();
        }
        

        return maxRoomWidth;
    }

    
    
    public IEnumerator SpawnRoom()
    {
        // spawn rooms şn a range that they will be inside of the maze bounds
        // transformPntExtens should be equal to length of the biggest room's edge
        
        for (int i = 0; i < roomCount; i++)
        {
            
            float x = Random.Range(-maze.size.x * 0.5f + transformPntExtens, maze.size.x * 0.5f - transformPntExtens);
            float z = Random.Range(-maze.size.z * 0.5f + transformPntExtens, maze.size.z * 0.5f - transformPntExtens);
            
            
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

                
                if ((point - points[j]).sqrMagnitude > distanceBetweenRooms * distanceBetweenRooms)
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
