using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CeilingCell : MonoBehaviour
{
    
    // initialize ceiling cells at position (x,z) make it child of a ceiling holder 
    public IntVector2 positionCeiling;
    
    public void Initialize(int positX, int positZ, Transform t)
    {
        positionCeiling.x = positX;
        positionCeiling.z = positZ;
        
        name = "Upper Cell" + positX + "," + positZ;
        transform.parent = t;
    }

    
}
