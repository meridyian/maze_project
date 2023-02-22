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


        }
        if (GUILayout.Button("Revert Changes")) 
        {
            roomWall.Reset();
        }

        
    }
}
