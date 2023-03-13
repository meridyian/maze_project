using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(50, 500)] 
    public float sens;

    public Transform body;
    private float xRot;

    private void Update()
    {
        // assign mouse look
        
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;
        transform.localRotation  = Quaternion.Euler(xRot, 0f, 0f);
        xRot = Mathf.Clamp(xRot, -80f, 80f);
        
        body.Rotate(Vector3.up * rotX);
    }
}
