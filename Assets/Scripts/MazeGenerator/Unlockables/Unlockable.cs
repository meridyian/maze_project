using UnityEngine;

namespace Assets.Scripts.MazeGenerator.Unlockables
{
    public abstract class Unlockable:MonoBehaviour, IUnlockable
    {
        public bool IsUnlocked { get; set; }
        public RoomObj Lock { get; set; }
        public abstract void OnUnlock();
    }
}