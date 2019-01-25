using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeGenerator.Services
{
    public class FileIOUtil
    {
        IDirectory directory;
        public FileIOUtil(IDirectory _directory)
        {
            directory = _directory;
        }
        public string GetTargetPath(string subPath = "")
        {
            string basePath = directory.GetPath();
            if (subPath == null || subPath == "")
                return Path.Combine(new string[] { basePath, "Templates", subPath });
            else
                return Path.Combine(new string[] { basePath, "Templates" });
        }

        public string[] GetAllFolders()
        {
            return Directory.GetDirectories(GetTargetPath());
        }

        public string[] GetAllFiles()
        {
            return Directory.GetFiles(GetTargetPath());
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

        public bool DeleteFile(string path)
        {
            if (!File.Exists(path))
                return false;
            try
            {
                File.Delete(path);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
