using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] 
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
    }

    private void MovePlayer()
    {
        // calculate movement direction 
        // to be able to move in the direction of eye
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    
    
    
    
}
