using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

[System.Serializable]
public struct IntVector2 
// to be able to change 
{
    public int x, z;

    public IntVector2(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public static IntVector2 operator + (IntVector2 a, IntVector2 b)
    {
        // to be able to add vectors only using units
        a.x += b.x;
        a.z += b.z;

        return a;
    }
}
