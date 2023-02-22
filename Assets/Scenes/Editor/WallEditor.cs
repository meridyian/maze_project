using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DoortoWall))]


public class WallEditor : Editor 
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DoortoWall doortoWall = (DoortoWall)target;
        
        if (GUILayout.Button("Door to RoomWall"))
        {
            doortoWall.ChangeDoortoWall();
            Debug.Log("Door is converted to roomwall");
           
        }

        if (GUILayout.Button("Revert Changes"))
        {
            doortoWall.RevertChanges();
        }

    }
}
