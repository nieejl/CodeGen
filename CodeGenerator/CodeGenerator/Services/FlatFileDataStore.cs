using CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Services
{
    public class FlatFileDataStore : IDataStore<CodeTemplate>
    {
        private FileIOUtil IOUtil;
        public FlatFileDataStore(IDirectory directory)
        {
            IOUtil = new FileIOUtil(directory);
            string path = IOUtil.GetTargetPath("Templates");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private const string FILE_EXTENSION = ".tem";
        public Task<bool> AddItemAsync(CodeTemplate item)
        {
            var sb = new StringBuilder();
            sb.AppendLine(item.Id);
            sb.AppendLine(item.Description);
            sb.AppendLine(item.Content);

            string targetPath = IOUtil.GetTargetPath(item.Id + FILE_EXTENSION);
            return Task.FromResult(IOUtil.WriteToFile(targetPath, sb.ToString()));
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await Task.FromResult(IOUtil.DeleteFile(id + FILE_EXTENSION));
        }

        public async Task<CodeTemplate> GetItemAsync(string id)
        {
            string targetPath = IOUtil.GetTargetPath(id + FILE_EXTENSION);
            string template = IOUtil.ImportFileToString(targetPath);
            return await Task.FromResult(CodeTemplate.FromString(template));
        }

        public async Task<IEnumerable<CodeTemplate>> GetItemsAsync(bool forceRefresh = false)
        {
            string[] templatePaths = IOUtil.GetAllFiles();
            IEnumerable<string> templateStrings = templatePaths.Select(tp => IOUtil.ImportFileToString(tp));
            IEnumerable<CodeTemplate> templates = templateStrings.Select(ts => CodeTemplate.FromString(ts));
            return await Task.FromResult(templates);
        }

        public Task<bool> UpdateItemAsync(CodeTemplate item)
        {
            string targetPath = IOUtil.GetTargetPath(item.Id + FILE_EXTENSION); 
            //return FileIOUtil.WriteToFile( item.Id + FILE_EXTENSION, //TODO: implement ToString() in codetemplate and finish
            throw new NotImplementedException();
        }
    }
}
