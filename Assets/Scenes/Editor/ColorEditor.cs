using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoomObj))]
public class ColorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RoomObj roomObj = (RoomObj)target;

        if (GUILayout.Button("Change Color"))
        {
            roomObj.SetRandomColor();
            roomObj.SetFloorColor();
        }
    
    }
}
