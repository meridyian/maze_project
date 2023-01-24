using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{
    public RoomObj roomPrefab;
    public float distanceBetweenRooms = 3f;
    private List<Vector3> points = new List<Vector3>();
    public int roomCount;
    public Maze maze;


    public IEnumerator SpawnRoom()
    {
         

        for (int i = 0; i < roomCount; i++)
        {
            
            float x = Random.Range(-maze.size.x * 0.5f + 2f, maze.size.x * 0.5f - 2f);
            float z = Random.Range(-maze.size.z * 0.5f + 2f, maze.size.z * 0.5f - 2f);
            
            
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

        yield return new WaitForSeconds(3);
        for (int i = 0; i < points.Count; i++)
        {
            Instantiate(roomPrefab, points[i], Quaternion.identity);
            Debug.Log(points[i]);
        }
        
    }




}
