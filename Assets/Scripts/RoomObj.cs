using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class RoomObj : MonoBehaviour
{
    [SerializeField]
    public List<Transform> roomWalls;

    public GameObject doorPrefab;


    private void Start()
    {
        StartCoroutine(SpawnDoors());
    }


    private void Awake()
    {
        roomWalls = new List<Transform>();
        int iter = gameObject.transform.childCount;

        for (int i = 0; i < iter; i++)
        {
            roomWalls.Add(gameObject.transform.GetChild(i));
        }
        Debug.Log("ok");

    }
    
    public void OnTriggerEnter(Collider other)
    {
        // &&onBounds()
        
        
        if (other.gameObject.CompareTag("Wall"))
        {

            //playercanPass = false;
            other.gameObject.SetActive(false);
        }
        
        
    } 

    public IEnumerator SpawnDoors()
    {
        yield return new WaitForSeconds(15);
        int transformLength = roomWalls.Count;
        for (int i = 0; i < transformLength; i++)
        {
            Instantiate(doorPrefab, roomWalls[i].position ,roomWalls[i].rotation, GetComponent<Transform>());
            roomWalls[i].gameObject.SetActive(false);
        }
        
    }

    
}
