using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToWall : MonoBehaviour
{
    private List<Transform> deactivatedWalls;

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
        
        
        /*
        deactivatedWalls = transform.parent.parent.GetComponent<RoomObj>().roomWalls;
        for (int wall = 0; wall < deactivatedWalls.Count; wall++)
        {
            if (transform.parent.position == deactivatedWalls[wall].transform.position)
            {
                deactivatedWalls[wall].gameObject.SetActive(true);
                transform.parent.gameObject.SetActive(false);
                return;
            }
            wall++;
        }*/
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
        
        
        
        /*deactivatedWalls = transform.parent.parent.GetComponent<RoomObj>().roomWalls;
        for (int wall = 0; wall < deactivatedWalls.Count; wall++)
        {
            if (transform.parent.position == deactivatedWalls[wall].transform.position)
            {
                deactivatedWalls[wall].gameObject.SetActive(false);
                transform.parent.gameObject.SetActive(true);
                return;
            }
            wall++;
        }
        */
        
    }

    
}
