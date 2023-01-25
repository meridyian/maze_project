using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public static bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;


    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }



    void Update()
    {
        if (inTrigger)
        {
            if (close)
            {
                if (doorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = true;
                        close = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    close = true;
                    open = false;

                }
            }
        }
        
        if (inTrigger)
        {
            if (open)
            {
                var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
                transform.rotation = newRot;
            }
            else 
            {
                var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
                transform.rotation = newRot;
            }
        }
    }

    private void OnGUI()
    {
        if(inTrigger)
        {
            if (open)
            {
                GUI.Box(new Rect(0,0,200,25), "press e to close");
            }
            else
            {
                if (doorKey)
                {
                    GUI.Box(new Rect(0,0,200,25), "press e to open");
                }
                else
                {
                    GUI.Box(new Rect(0,0,200, 25), "need a key");
                }
            }
        }
    }
}
