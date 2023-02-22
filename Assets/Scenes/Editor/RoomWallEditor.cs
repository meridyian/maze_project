using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomWall))]

public class RoomWallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RoomWall roomWall = (RoomWall)target;

        if (GUILayout.Button("RoomWall to Door"))
        {
            roomWall.MakeDoor();
            Debug.Log("Door is converted to roomwall");

        }
        if (GUILayout.Button("Revert Changes")) 
        {
            roomWall.RevertChanges();
        }

        
    }
}
