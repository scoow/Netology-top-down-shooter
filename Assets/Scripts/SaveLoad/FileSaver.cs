using System.Collections.Generic;
using System.IO;

namespace TDShooter.SaveLoad
{
    /// <summary>
    /// Сохранение прогресса игры в файл
    /// </summary>
    public class FileSaver : ISaver
    {
        private readonly string _path = "save.txt";
        private readonly List<ISavable>  _savables;

        public FileSaver(List<ISavable> savables)
        {
            _savables = savables;
        }

        public void Load()
        {
            int i = 0;
            using StreamReader sr = new(_path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                _savables[i].LoadThis(line);
                i++;
            }
        }

        public void Save()
        {
            using StreamWriter sw = new(_path, false);
            foreach (var savable in _savables)
            {
                sw.WriteLine(savable.SaveThis());
            }
        }
    }
}