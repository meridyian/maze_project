using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] 
    public float moveSpeed;
    
    // keep orientation to give the camera
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
    
    
    // remove upper ceilings with Raycast to open minimap

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
                
                hit.transform.gameObject.SetActive(false);
                
            }
            
        }
        
       
    }
    

    private void FixedUpdate()
    { 
        SpeedControl();
        MovePlayer();
        
        
        
    }
    
    // player movement
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

    // control the player speed
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
