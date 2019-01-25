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
        public string CreateDirectory(string name)
        {
            Task.WaitAll(baseFolder.CreateFolderAsync(name).AsTask());
            var path = "abc";
            return path;
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
