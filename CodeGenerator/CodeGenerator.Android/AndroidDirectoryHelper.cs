using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CodeGenerator.Droid;
using CodeGenerator.Services;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;

[assembly: Dependency(typeof(AndroidDirectoryHelper))]
namespace CodeGenerator.Droid
{
    public class AndroidDirectoryHelper : IDirectory
    {
        public Task<bool> ContainsItemAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateDirectoryAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateFileAsync(string name, string content)
        {
            throw new NotImplementedException();
        }

        public string GetPath()
        {
            throw new NotImplementedException();
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