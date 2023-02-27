using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color", menuName = "RoomColor")]
public class RoomSO : ScriptableObject
{
    public Color smallRoomColor;
    public Color bigRoomColor;
    public Color startingCell;
    
}
