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

[assembly: Dependency(typeof(AndroidDirectoryHelper))]
namespace CodeGenerator.Droid
{
    public class AndroidDirectoryHelper : IDirectory
    {
        public string CreateDirectory(string name)
        {
            throw new NotImplementedException();
        }

        public string GetPath()
        {
            return FileSystem.AppDataDirectory;
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