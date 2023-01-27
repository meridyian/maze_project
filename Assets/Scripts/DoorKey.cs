using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public bool inTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            inTrigger = false;
    }

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //DoorScript.doorKey = true;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
        }
    }
}
