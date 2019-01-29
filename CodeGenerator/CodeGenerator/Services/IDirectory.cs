using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Services
{
    public interface IDirectory
    {
        Task<string> CreateDirectoryAsync(string name);
        Task<string> CreateFileAsync(string name, string content);
        bool RemoveDirectory();
        Task<bool> ContainsItemAsync(string name);
        string RenameDirectory(string oldName, string newName);
        string GetPath();
    }
}
