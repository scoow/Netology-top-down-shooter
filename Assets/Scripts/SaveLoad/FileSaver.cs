using System.Collections.Generic;
using System.IO;
using TDShooter.Managers;
using UnityEngine;

namespace TDShooter.SaveLoad
{
    public class FileSaver : ISaver
    {
        private readonly string _path = "save.txt";
        private readonly List<ISavable>  _savables;
        private PlayerProgress _progress;

        public FileSaver(List<ISavable> savables)
        {
            _savables = savables;
/*            _progress = FindObjectOfType<PlayerProgress>();
            _savables.Add(_progress);*/
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