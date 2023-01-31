using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{
    public RoomObj[] roomPrefabs;
    public RoomObj roomObjScript;
    public float distanceBetweenRooms;
    private List<Vector3> points = new List<Vector3>();
    private GameManager gameManager;
    public Maze maze;
    private MazeCell mazeCell;
    private float maxRoomWidth;
    public int trialCount;
    

    public int numofKeys;
    
    private RoomWall roomWall;

    public float transformPntExtens = 3.5f;


    public List<float> x = new List<float>();
    private List<Vector3> keySpawnpoints = new List<Vector3>();
    
    public void Awake()
    {
        SetSize();
    }

    
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
        
        
        for (int i = 0; i < trialCount; i++)
        {
            // deadend listte celller tutuluyo, 
            // celllerin transformlarının değerlerini çekip bulnar arasında oluşturabilirsin
            
            float x = Random.Range(-maze.size.x * 0.5f + transformPntExtens, maze.size.x * 0.5f - transformPntExtens);
            float z = Random.Range(-maze.size.z * 0.5f + transformPntExtens, maze.size.z * 0.5f - transformPntExtens);
            
            
            Vector3 point = new Vector3(Mathf.RoundToInt(x), 0.5f, Mathf.RoundToInt(z));

            if (points.Count == 0)
            {
                points.Add(point);
                i++;
                continue;
            }

            for (int j = 0; j < points.Count; j++)
            {
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
            int randomIndex = Random.Range(0, roomPrefabs.Length);
            Instantiate(roomPrefabs[randomIndex], points[i], Quaternion.identity);
            Debug.Log(points[i]);
            
        }
        
        StartCoroutine(roomObjScript.SpawnDoors());

        
        
    }
    

}
