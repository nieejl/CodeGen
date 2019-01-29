using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Services
{
    public class FileIOUtil
    {
        IDirectory directory;
        public FileIOUtil(IDirectory _directory)
        {
            directory = _directory;
            Task.FromResult(CreateFolderIfAbsent("Templates"));
        }


        private async Task CreateFolderIfAbsent(string name)
        {
            if (await directory.ContainsItemAsync("Templates"))
                await directory.CreateDirectoryAsync("Templates");
        }
        public string GetSubPath(string subPath = "")
        {
            string basePath = "Templates";
            if (subPath == null || subPath == "")
                return "Templates";
            else
                return Path.Combine(new string[] { basePath, subPath });
        }

        public string GetAbsolutePath()
        {
            return Path.Combine(directory.GetPath(), GetSubPath());
        }

        public string[] GetAllFolders()
        {
            return Directory.GetDirectories(GetAbsolutePath());
        }

        public string[] GetAllFiles()
        {
            return Directory.GetFiles(GetAbsolutePath());
        }

        public async Task<bool> WriteToFile(string targetPath, string content, bool overwrite = false)
        {
            bool exists = await directory.ContainsItemAsync(targetPath);
            if (exists && !overwrite)
                return false;
            var file = await directory.CreateFileAsync(targetPath, content);
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
