namespace RPG.Saving
{
    public interface ISaveableT
    {
        object CaptureState();
        void RestoreState(object state);
    }
}