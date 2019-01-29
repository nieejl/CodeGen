using CodeGenerator.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using CodeGenerator.UWP;
using Xamarin.Forms;
using System.Diagnostics;

[assembly: Dependency(typeof(UWPDirectoryHelper))]
namespace CodeGenerator.UWP
{
    public class UWPDirectoryHelper : IDirectory
    {
        StorageFolder baseFolder = ApplicationData.Current.LocalFolder;
        public UWPDirectoryHelper()
        {
            Debug.WriteLine(baseFolder.Path);
        }
        public async Task<string> CreateDirectoryAsync(string name)
        {
            var createdFolder = await baseFolder.CreateFolderAsync(name);
            return createdFolder.Path;
        }

        public async Task<bool> ContainsItemAsync(string name)
        {
            var file = await baseFolder.TryGetItemAsync(name);
            return file != null;
        }

        public async Task<string> CreateFileAsync(string name, string content)
        {
            var createdFile = await baseFolder.CreateFileAsync(name);
            await FileIO.WriteTextAsync(createdFile, content);
            return createdFile.Path;
        }

        public string GetPath()
        {
            return baseFolder.Path;
        }

        public bool RemoveDirectory()
        {
            throw new NotImplementedException();
        }

        public string RenameDirectory(string oldName, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
