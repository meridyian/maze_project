using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class RoomWall : MonoBehaviour
{
    
    // after spawning the room, remove walls that collide with the room
    
    public void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Wall"))
        {
            StartCoroutine(RemoveWalls());
            other.gameObject.SetActive(false);


        }


    }


    private IEnumerator RemoveWalls()
    {
        yield return new WaitForSeconds(0.5f);
        
        GetComponent<Transform>().parent.gameObject.GetComponent<RoomObj>().roomWalls.Remove(
            GetComponent<Transform>());

        
    }
    
    
    public void MakeDoor()
    {
        gameObject.SetActive(false);
        GameObject doorPref = transform.parent.GetComponent<RoomObj>().doorPrefab; 
        GameObject doorObj = Instantiate(doorPref, transform.position, transform.rotation);
        doorObj.transform.parent = transform.parent;
        doorObj.name = gameObject.name + " Door";
    }

    public void Reset()
    { 
        gameObject.SetActive(true);

        foreach (Transform doors in transform.parent.transform)
        {
            if(doors.name.StartsWith(gameObject.name + " Door"))
                DestroyImmediate(doors.gameObject);

        }
        
    }
    

}
