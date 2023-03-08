using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    
    // speed should be more than agent speed
    [Header("Movement")] 
    public float moveSpeed;
    public Transform orientation;
    public float range = 5f;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    
    // to save player data
    public string vec3;
    public Vector3 playerReload;
    public static TestPlayerMovement instance;
    public List<string> removedceilings = new List<string>();
    
    
    // controller of testmanager script to load the data when reload button is pressed
    public bool playerIsThere;
    
    
    private void Awake()
    {
        // create singleton to be able to reach player after it is spawned
        if (instance != null) return;
        instance = this;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        LoadPlayer();

    }
    
    // Activated whe Reload button is pressed
    public void LoadPlayer()
    {
        if (playerIsThere)
        {
            PlayerData data = SaveSystem.LoadGame();
            
            // check if there is no player data for exception
            if (data == null)
            {
                return; 
            }
            
            // transform saved position string into vector3 for updating the real position
            vec3 = data.playerPos;
            string[] vec3arr = vec3.Split(new char[] { ',',' ',')', '(','"'});
            playerReload = new Vector3(float.Parse(vec3arr[1]), float.Parse(vec3arr[3]), float.Parse(vec3arr[5]));
            transform.position = playerReload;
            
            // reload minimap
            removedceilings = data.ceilings;
            foreach (var ceilings in removedceilings)
            {
                // since player is spawned later find the maze object from singleton
                TestManagerScript.testinstance.maze.transform.GetChild(0).Find(ceilings).gameObject.SetActive(false);
            }

        }
        


    }
    
    // take input at each frame,
    // to open minimap, disable the ceilings that you've already passed 

    public void Update()
    {
        MyInput();

        Vector3 direction = Vector3.up;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Ceiling")
            {
                // keep name of the ceilings to save
                removedceilings.Add(hit.transform.parent.name);
                hit.transform.gameObject.SetActive(false);

            }
        }
        
    }
    
    // Player movement
    
    private void FixedUpdate()
    { 
        SpeedControl();
        MovePlayer();
        
        // update player position to save
        vec3 = transform.position.ToString();

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
