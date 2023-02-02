using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public Transform player;
    public Camera minimapCamera;
    public Shader fadeShader;

    public RenderTexture minimapTexture;
    private Material fadeMaterial;

    private void Start()
    {
        // Creating a render texture for the minimap
        minimapCamera.targetTexture = minimapTexture;
        
        // Create a material for the fade shader
        fadeMaterial = new Material(fadeShader);
        fadeMaterial.SetFloat("_Fade", 0.0f);
    }

    private void Update()
    {
        // Update the position of the minimap camera to match the player's position
        minimapCamera.transform.position =
            new Vector3(player.position.x, minimapCamera.transform.position.y, player.position.z);
        
        // Gradually increase the fade value of the material
        fadeMaterial.SetFloat("_Fade", Mathf.Clamp01(fadeMaterial.GetFloat("_Fade") + Time.deltaTime));
    }

    
}
