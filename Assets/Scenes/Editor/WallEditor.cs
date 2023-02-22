using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DoorToWall))]


public class WallEditor : Editor 
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DoorToWall doortoWall = (DoorToWall)target;
        
        if (GUILayout.Button("Door to RoomWall"))
        {
            doortoWall.ChangeDoorToWall();

        }

        if (GUILayout.Button("Reset"))
        {
            doortoWall.Reset();
        }

    }
}
