using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CeilingCell : MonoBehaviour
{
    public IntVector2 positionCeiling;

    // initialize ceiling cells at position (x,z) make it child of given
    
    public void Initialize(int positX, int positZ, Transform t)
    {
        positionCeiling.x = positX;
        positionCeiling.z = positZ;
        
        name = "Upper Cell" + positX + "," + positZ;
        transform.parent = t;
    }

    
}
