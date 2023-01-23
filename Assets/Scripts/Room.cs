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



    public IEnumerator SpawnRoom()
    {
        int count = 15;

        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(-4, 4);
            float z = Random.Range(-4, 4);

            Vector3 point = new Vector3(x, 0.5f, z);

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
        }
        
    }




}
