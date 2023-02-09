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
    
    // if the player is on the ground apply drag

    public Transform orientation;
    public float range = 5f;
    float horizontalInput;
    float verticalInput;
    private GameTimer gameTimer;

    public string vec3;

    public static PlayerMovement instance;
    
    Vector3 moveDirection;
    Rigidbody rb;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
        LoadPlayer();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        vec3 = "edd";
        Debug.Log("XXXX");

    }
    public void SavePlayer()
    {
       // SaveSystem.SavePlayer(this, null);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

     //   vec3 = data.playerPos;
/*
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        //vec3 = position.ToString();
*/
    }

    /*public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    } 
    */
    
    

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

    private void OnApplicationQuit()
    {
     //   SavePlayer();
    }
}
