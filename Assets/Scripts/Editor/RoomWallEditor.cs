using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomWall))]

public class RoomWallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RoomWall roomWall = (RoomWall)target;
        string text;
        
        if (roomWall.IsConverted)
            text = "Change Back";
        else
            text = "RoomWall to Door";

        
        if (GUILayout.Button(text))
        {
            if (!roomWall.IsConverted)
            {
                roomWall.IsConverted = true;
                roomWall.MakeDoor();
            }
            else
            {
                roomWall.IsConverted = false;
                roomWall.Reset();
            }
            
        }
        
        
    }
}
