using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JWLHalperHalper
{
    public class GetIniFiles
    {
        public static List<KeyValuePair<string, string>> GetFiles()
        {
            var files = new List<KeyValuePair<string, string>>();

            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JWLHelper";

            var filesList = Directory.GetFiles(path).Where(f => f.StartsWith(path + "\\JWLHelper") && f.EndsWith("ini")).ToList();
            filesList.Remove(path + "\\JWLHelper.ini");
            files = filesList.Select(f => new KeyValuePair<string, string>(f.Replace(path + "\\", ""), f)).ToList();

            return files;
        }
    }
}
