using UnityEngine;

namespace Assets.Scripts.MazeGenerator.Unlockables
{
    public class DummyLock : Unlockable
    {
       

        public override void OnUnlock()
        {
            Lock.TryUnlock();
        }
        
    }
}