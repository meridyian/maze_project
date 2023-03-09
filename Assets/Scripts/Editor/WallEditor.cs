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

        string text;
        if (doortoWall.doorConverted)
            text = "Change back";
        else
            text = "Door to RoomWall";



        if (GUILayout.Button(text))
        {
            if (!doortoWall.doorConverted)
            {
                doortoWall.doorConverted = true;
                doortoWall.ChangeDoorToWall();
            }
            else
            {
                doortoWall.doorConverted = false;
                doortoWall.Reset();
            }

        }

    }
}
