using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FengShuiNumber.Helpers
{
    public class WriteJsonFile
    {
        public static string Create(string json, string fileName)
        {
            var contextPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (contextPath == null)
            {
                return null;
            }

            string folder_path = Path.Combine(contextPath, "Data");

            if (!Directory.Exists(folder_path))
            {
                Directory.CreateDirectory(folder_path);
            }

            string path = Path.Combine(folder_path, $"{fileName}.json");

            File.WriteAllText(path, json);

            return path;
        }
    }
}
