using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoomObj))]
[CanEditMultipleObjects]
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
