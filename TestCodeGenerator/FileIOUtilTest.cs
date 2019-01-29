using CodeGenerator.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestCodeGenerator
{
    public class FileIOUtilTest
    {
        
        private FileIOUtil CreateIOUtil()
        {
            string root = CreateRootString();
            var mock = new Mock<IDirectory>();
            mock.Setup(m => m.GetPath()).Returns(root);
            return new FileIOUtil(mock.Object);
        }

        private string CreateRootString()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Test");
            if (!File.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        [Fact]
        public async Task Test_WriteToFile_Given_Existing_File_And_False_Returns_False() {
            string root = CreateRootString();
            var ioUtil = CreateIOUtil();
            string targetPath = Path.Combine(root, "wtf_false_test.txt");

            File.WriteAllText(targetPath, "File not overwritten");
            var result = await ioUtil.WriteToFile(targetPath, "File Created");

            Assert.False(result);
        }

        [Fact]
        public async Task Test_WriteToFile_Given_Existing_File_And_False_Does_Not_Write_File()
        {
            string root = CreateRootString();
            var ioUtil = CreateIOUtil();
            string targetPath = Path.Combine(root, "wtf_false_test.txt");

            File.WriteAllText(targetPath, "File not overwritten");
            await ioUtil.WriteToFile(targetPath, "File Created", false);
            var result = File.ReadAllText(targetPath);

            Assert.Equal("File not overwritten", result);
        }

        [Fact]
        public void Test_WriteToFile_Given_Existing_File_And_True_Overwrites_Existing_File()
        {
            string root = CreateRootString();
            var ioUtil = CreateIOUtil();
            string targetPath = Path.Combine(root, "wtf_exist_true_test.txt");
            File.WriteAllText(targetPath, "File not overwritten");

            ioUtil.WriteToFile(targetPath, "File Created", true);
            var result = File.ReadAllText(targetPath);

            Assert.Equal("File Created", result);
        }

        [Fact]
        public void Test_WriteToFile_Given_Non_Existing_Path_Creates_File()
        {
            string root = CreateRootString();
            var ioUtil = CreateIOUtil();
            string targetPath = Path.Combine(root, "wtf_exist_true_test.txt");

            ioUtil.WriteToFile(targetPath, "File Created");
            var result = File.ReadAllText(targetPath);

            Assert.Equal("File Created", result);
        }

        [Fact]
        public void Test_ImportFileToString_Given_Existing_Returns_File_As_String()
        {
            string root = CreateRootString();
            var ioUtil = CreateIOUtil();
            string targetPath = Path.Combine(root, "ifts_exist_test.txt");

            File.WriteAllText(targetPath, "File read");
            var result = ioUtil.ImportFileToString(targetPath);

            Assert.Equal("File read", result);
        }

        [Fact]
        public void Test_ImportFileToString_Given_Non_Existing_Returns_Empty_String()
        {
            string root = CreateRootString();
            var ioUtil = CreateIOUtil();
            string targetPath = Path.Combine(root, "ifts_non_existing_test.txt");

            var result = ioUtil.ImportFileToString(targetPath);

            Assert.Equal("", result);
        }


    }
}
