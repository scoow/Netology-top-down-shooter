using System.Collections.Generic;
using System.IO;
using TDShooter.Managers;
using UnityEngine;
using Zenject;

namespace TDShooter.SaveLoad
{
    public class FileSaver : MonoBehaviour, ISaver
    {
        private readonly string _path = "save.txt";
        private readonly List<ISavable>  _savables = new();
        [Inject]
        private PlayerProgress _progress;

        private void Awake()
        {
            _savables.Add(_progress);
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
            using StreamWriter sw = new(_path, true);
            foreach (var savable in _savables)
            {
                sw.WriteLine(savable.SaveThis());
            }
        }
    }
}