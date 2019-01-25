using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Services
{
    public interface IDirectory
    {
        string CreateDirectory(string name);
        bool RemoveDirectory();
        string RenameDirectory(string oldName, string newName);
        string GetPath();
    }
}
