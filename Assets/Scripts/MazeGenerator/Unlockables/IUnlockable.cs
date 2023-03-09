namespace Assets.Scripts.MazeGenerator.Unlockables
{
    public interface IUnlockable
    {
        public bool IsUnlocked { get; set; }
        RoomObj Lock { get; set; }
        void OnUnlock();
    }
}