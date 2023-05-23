using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TDShooter.Managers
{
    public class SaveLoadManager : MonoBehaviour
    {
        public Dictionary<string, string> ReadINIFile(string filename)
        {
            // Если файл не найден, вернуть null
            if (!File.Exists(filename)) return null;

            // Создать новый словарь
            Dictionary<string, string> INIFile = new();
            // Создать новый объект чтения из потока
            using (StreamReader SR = new(filename))
            {
                // Переменная для хранения текущей строки
                string Line;
                // Продолжать читать допустимые строки
                while (!string.IsNullOrEmpty(Line = SR.ReadLine()))
                {
                    // Удалить ведущие и конечные пробелы
                    Line.Trim();
                    // разбить строку на ключ и значение
                    string[] Parts = Line.Split(new char[] { '=' });
                    // Добавить в словарь
                    INIFile.Add(Parts[0].Trim(), Parts[1].Trim());
                }
            }
            // Вернуть словарь
            return INIFile;
        }

        public void SaveINIFile(Dictionary<string, string> dictionary, string filename)
        {
            using StreamWriter sw = new(filename, true);
            foreach (KeyValuePair<string, string> pair in dictionary)
                sw.WriteLine(pair.Key + '=' + pair.Value);
        }
    }
}