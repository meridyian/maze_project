using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class MazeCellWall : MonoBehaviour
{
    public float scaleSize;
    [SerializeField] private Maze maze;
    private bool visible = true;
    private Renderer r;
    private Collider c;
    //public bool playercanPass;

    public bool Visible
    {
        get { return visible; }
        set
        {
            visible = value;
            r.enabled = visible;

        }
    }

    

    public void Awake()
    {
        r = GetComponent<Renderer>();

    }
    
    /*public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Room Wall"))
        {
            
            gameObject.SetActive(false);

        }

        
        
    }
    */


}
