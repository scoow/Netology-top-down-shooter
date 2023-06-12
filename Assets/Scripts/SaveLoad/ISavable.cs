namespace TDShooter.SaveLoad
{
    /// <summary>
    /// Интерфейс сохраняемого элемента игры
    /// </summary>
    public interface ISavable
    {
        public string SaveThis();
        public void LoadThis(string data);
    }
}