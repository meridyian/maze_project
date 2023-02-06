using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomObj : MonoBehaviour
{
    [SerializeField]
    public List<Transform> roomWalls;
    public List<Transform> doorLocations;
    public GameObject doorPrefab;

    

    private int spawnDelay = 3;

    



    private void Start()
    { 
        StartCoroutine(SpawnDoors());
        List<Transform> doorLocations = new List<Transform>();
    }


    public void Awake()
    {
        roomWalls = new List<Transform>();
        int iter = gameObject.transform.childCount;

        for (int i = 0; i < iter; i++)
        {
            roomWalls.Add(gameObject.transform.GetChild(i));
        }
        Debug.Log("ok");

    }
    
    public void OnCollisionEnter(Collision other)
    {
        // &&onBounds()


        if (other.gameObject.CompareTag("Floor"))
        {
            Debug.Log( transform.name+ "collided with floor" + other.gameObject.transform.position);
            
            if(transform.name.StartsWith("Small Room"))
                other.gameObject.GetComponentInChildren<Renderer>().material.color = Color.blue;
            if(transform.name.StartsWith("Big Room"))
                other.gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
            
           
            
        }
        
        
        if (other.gameObject.CompareTag("Wall"))
        {
            
            other.gameObject.SetActive(false);
            transform.GetComponent<BoxCollider>().isTrigger = true;
            
        }

        
        
        
    }

    

    public IEnumerator SpawnDoors()
    {
        yield return new WaitForSeconds(spawnDelay);
        int transformLength = roomWalls.Count;
        for (int i = 0; i < transformLength; i++)
        {
            roomWalls[i].gameObject.SetActive(false);
            Instantiate(doorPrefab, roomWalls[i].position ,roomWalls[i].rotation, GetComponent<Transform>());
            doorLocations.Add(doorPrefab.GetComponentInParent<Transform>());
            Debug.Log(doorPrefab.GetComponentInParent<Transform>());
            
        }
        


        

    }

    
}
