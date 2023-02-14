using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
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
    public Vector3 playerReload;

    public static TestPlayerMovement instance;
    public List<string> removedceilings = new List<string>();


    Vector3 moveDirection;
    Rigidbody rb;
    
    
    private void Awake()
    {
        if (instance != null) return;
        instance = this;
        //vec3 = String.Empty;
        LoadPlayer();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        
        
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null)
        {
            return; 
        }
        
        vec3 = data.playerPos;
        string[] vec3arr = vec3.Split(new char[] { ',',' ',')', '(','"'});
        playerReload = new Vector3(float.Parse(vec3arr[1]), float.Parse(vec3arr[3]), float.Parse(vec3arr[5]));
        transform.position = playerReload;
        
        removedceilings = data.ceilings;
        


    }

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

                removedceilings.Add(hit.transform.parent.name);
                hit.transform.gameObject.SetActive(false);

            }
        }
        
    }
    
    private void FixedUpdate()
    { 
        SpeedControl();
        MovePlayer();
        
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
