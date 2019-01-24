using CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Services
{
    public class FlatFileDataStore : IDataStore<CodeTemplate>
    {
        private const string FILE_EXTENSION = ".tem";
        public Task<bool> AddItemAsync(CodeTemplate item)
        {
            var sb = new StringBuilder();
            sb.AppendLine(item.Id);
            sb.AppendLine(item.Description);
            sb.AppendLine(item.Content);

            string targetPath = FileIOUtil.GetTargetPath(item.Id + FILE_EXTENSION);
            return Task.FromResult(FileIOUtil.WriteToFile(targetPath, sb.ToString()));
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            return Task.FromResult(FileIOUtil.DeleteFile(id + FILE_EXTENSION));
            throw new NotImplementedException();
        }

        public Task<CodeTemplate> GetItemAsync(string id)
        {
            string targetPath = FileIOUtil.GetTargetPath(id + FILE_EXTENSION);
            string template = FileIOUtil.ImportFileToString(targetPath);
            return Task.FromResult(CodeTemplate.FromString(template));
        }

        public Task<IEnumerable<CodeTemplate>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(CodeTemplate item)
        {
            throw new NotImplementedException();
        }
    }
}
