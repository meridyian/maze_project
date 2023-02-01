using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomWall : MonoBehaviour
{

    
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name + "a");
        
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
