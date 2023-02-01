using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    // for camera
    public Transform orientation;

    float xRotation;
    private float yRotation;



    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        
        // to handle rotation and position
        yRotation += mouseX;
        xRotation -= mouseY;
        
        // cannot look up or down more than 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation,0);
        // rotate player along y axis
        orientation.rotation  =Quaternion.Euler(0, yRotation,0);
        
    }
}
