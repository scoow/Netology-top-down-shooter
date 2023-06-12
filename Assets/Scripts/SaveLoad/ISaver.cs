namespace TDShooter.SaveLoad
{
    /// <summary>
    /// Интерфейс для сохранения и загрузки прогресса игры
    /// </summary>
    public interface ISaver
    {
        public void Save();
        public void Load();
    }
}