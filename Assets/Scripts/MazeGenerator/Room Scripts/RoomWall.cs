using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    
}
