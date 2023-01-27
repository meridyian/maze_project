using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomWall : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "a");
        
        if (other.gameObject.CompareTag("Wall"))
        {
            StartCoroutine(RemoveWalls());

            //other.gameObject.GetComponent<Renderer>().material.color = Color.black;
            //gameObject.GetComponent<Renderer>().material.color = Color.red;


        }


    }


    private IEnumerator RemoveWalls()
    {
        yield return new WaitForSeconds(0.5f);
        
        GetComponent<Transform>().parent.gameObject.GetComponent<RoomObj>().roomWalls.Remove(
            GetComponent<Transform>());
    }
    
}
