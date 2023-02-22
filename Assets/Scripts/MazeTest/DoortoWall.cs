using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoortoWall : MonoBehaviour
{
    private List<Transform> deactivatedWalls;

    public void ChangeDoortoWall()
    {
        deactivatedWalls = gameObject.transform.parent.parent.GetComponent<RoomObj>().roomWalls;
        Debug.Log(deactivatedWalls[0]);
        for (int wall = 0; wall < deactivatedWalls.Count; wall++)
        {
            if (transform.parent.transform.position == deactivatedWalls[wall].transform.position)
            {
                deactivatedWalls[wall].gameObject.SetActive(true);
                transform.parent.gameObject.SetActive(false);
                return;
            }
            wall++;
        }
    }

    public void RevertChanges()
    {
        deactivatedWalls = gameObject.transform.parent.parent.GetComponent<RoomObj>().roomWalls;
        for (int wall = 0; wall < deactivatedWalls.Count; wall++)
        {
            if (transform.parent.transform.position == deactivatedWalls[wall].transform.position)
            {
                deactivatedWalls[wall].gameObject.SetActive(false);
                transform.parent.gameObject.SetActive(true);
                return;
            }
            wall++;
        }
        
    }

    
}
