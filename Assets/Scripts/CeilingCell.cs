using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CeilingCell : MonoBehaviour
{
    public IntVector2 positionCeiling;

    
    public void Initialize(int positX, int positZ, Transform t)
    {
        positionCeiling.x = positX;
        positionCeiling.z = positZ;
        
        name = "Upper Cell" + positX + "," + positZ;
        transform.parent = t;
    }

    

    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.GetComponent<SpherewwwaCollider>().isTrigger = true;
        }
        
    }
    */
}
