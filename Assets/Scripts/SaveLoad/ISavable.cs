namespace TDShooter.SaveLoad
{
    public interface ISavable
    {
        public string SaveThis();
        public void LoadThis(string data);
    }
}