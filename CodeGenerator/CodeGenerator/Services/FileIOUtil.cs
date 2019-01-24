using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CodeGenerator.Services
{
    public class FileIOUtil
    {
        public static string GetTargetPath(string subPath)
        {
            return Path.Combine(new string[] { Directory.GetCurrentDirectory(), subPath });
        }

        public static bool WriteToFile(string targetPath, string content, bool overwrite = false)
        {
            if (File.Exists(targetPath) && !overwrite)
                return false;
            File.WriteAllText(targetPath, content);
            return true;
        }

        public static string ImportFileToString(string path)
        {
            if (!File.Exists(path))
                return "";
            var stringContent = File.ReadAllText(path);
            return stringContent;
        }

        public static bool DeleteFile(string path)
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
