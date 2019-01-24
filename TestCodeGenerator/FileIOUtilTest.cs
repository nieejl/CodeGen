using CodeGenerator.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace TestCodeGenerator
{
    public class FileIOUtilTest
    {
        [Fact]
        public void Test_GetTargetPath_Given_Path_Returns_Root_Plus_Path()
        {
            string root = Directory.GetCurrentDirectory();
            string path = "123";

            var result = FileIOUtil.GetTargetPath(path);

            Assert.Equal(root + @"\" + path, result);
        }

        [Fact]
        public void Test_WriteToFile_Given_Existing_File_And_False_Returns_False() {
            string root = Directory.GetCurrentDirectory();
            string targetPath = Path.Combine(root, "wtf_false_test.txt");

            File.WriteAllText(targetPath, "File not overwritten");
            var result = FileIOUtil.WriteToFile(targetPath, "File Created");

            Assert.False(result);
        }

        [Fact]
        public void Test_WriteToFile_Given_Existing_File_And_False_Does_Not_Write_File()
        {
            string root = Directory.GetCurrentDirectory();
            string targetPath = Path.Combine(root, "wtf_false_test.txt");

            File.WriteAllText(targetPath, "File not overwritten");
            FileIOUtil.WriteToFile(targetPath, "File Created", false);
            var result = File.ReadAllText(targetPath);

            Assert.Equal("File not overwritten", result);
        }

        [Fact]
        public void Test_WriteToFile_Given_Existing_File_And_True_Overwrites_Existing_File()
        {
            string root = Directory.GetCurrentDirectory();
            string targetPath = Path.Combine("wtf_exist_true_test.txt");
            File.WriteAllText(targetPath, "File not overwritten");

            FileIOUtil.WriteToFile(targetPath, "File Created", true);
            var result = File.ReadAllText(targetPath);

            Assert.Equal("File Created", result);
        }

        [Fact]
        public void Test_WriteToFile_Given_Non_Existing_Path_Creates_File()
        {
            string root = Directory.GetCurrentDirectory();
            string targetPath = Path.Combine("wtf_exist_true_test.txt");

            FileIOUtil.WriteToFile(targetPath, "File Created");
            var result = File.ReadAllText(targetPath);

            Assert.Equal("File Created", result);
        }

        [Fact]
        public void Test_ImportFileToString_Given_Existing_Returns_File_As_String()
        {
            string root = Directory.GetCurrentDirectory();
            string targetPath = Path.Combine("ifts_exist_test.txt");

            File.WriteAllText(targetPath, "File read");
            var result = FileIOUtil.ImportFileToString(targetPath);

            Assert.Equal("File read", result);
        }

        [Fact]
        public void Test_ImportFileToString_Given_Non_Existing_Returns_Empty_String()
        {
            string root = Directory.GetCurrentDirectory();
            string targetPath = Path.Combine("ifts_non_existing_test.txt");

            var result = FileIOUtil.ImportFileToString(targetPath);

            Assert.Equal("", result);
        }


    }
}
