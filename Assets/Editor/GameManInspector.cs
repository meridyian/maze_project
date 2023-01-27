using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GameManager))]
public class GameManInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager gameManager = (GameManager)target;
        
        if (GUILayout.Button("Generate Maze"))
        {
            gameManager.BeginGame();
        }
            
        if (GUILayout.Button("Reset Maze"))
        {
            gameManager.RestartGame();
        }
        
    }
}
