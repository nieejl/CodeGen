using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CodeGenerator.Services
{
    public class FileImporter
    {
        private string RootDirectory;
        public FileImporter()
        {
            RootDirectory = Directory.GetCurrentDirectory();
            Debug.WriteLine(RootDirectory);
        }

        public string GetTargetPath(string subPath)
        {
            return Path.Combine(new string[] { RootDirectory, subPath });
        }

        public bool WriteToFile(string targetPath, string content, bool overwrite = false)
        {
            if (File.Exists(targetPath) && !overwrite)
                return false;
            File.WriteAllText(targetPath, content);
            return true;
        }

        public string ImportFileToString(string path)
        {
            if (!File.Exists(path))
                return "";
            var stringContent = File.ReadAllText(path);
            return stringContent;
        }
    }
}
