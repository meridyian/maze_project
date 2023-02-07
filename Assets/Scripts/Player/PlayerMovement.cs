using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] 
    public float moveSpeed;

    public Room room;
    
    // if the player is on the ground apply drag

    public Transform orientation;
    public float range = 5f;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    private void Update()
    {
        MyInput();
        
        Vector3 direction = Vector3.up;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Ceiling")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
    

    private void FixedUpdate()
    {
        
        SpeedControl();
        if(room.canMove == true)
            MovePlayer();
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
    }

    public void MovePlayer()
    {
        
        
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.velocity = new Vector3(moveDirection.x, 0f, moveDirection.z);
            //rb.AddForce(moveDirection.normalized * moveSpeed , ForceMode.Force);
        }
        
        
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    
    
    
    
}
