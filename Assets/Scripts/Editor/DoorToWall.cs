using System.Collections.Generic;
using UnityEngine;

public class DoorToWall : MonoBehaviour
{
    private List<Transform> deactivatedWalls;
    public bool doorConverted { get; set; }
    public void ChangeDoorToWall()
    {
        transform.parent.gameObject.SetActive(false);
        foreach (Transform walls in transform.parent.parent.transform)
        {
            if (walls.transform.position == transform.parent.position)
            {
                walls.gameObject.SetActive(true);
                transform.parent.gameObject.SetActive(false);
            }
        }
        
        
    }

    public void Reset()
    {
        transform.parent.gameObject.SetActive(true);
        foreach (Transform walls in transform.parent.parent.transform)
        {
            if (walls.transform.position == transform.parent.position)
            {
                walls.gameObject.SetActive(false);
                transform.parent.gameObject.SetActive(true);
            }
        }
        
        
        
    }

    
}
