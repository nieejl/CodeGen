using CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCodeGenerator
{
    public class CodeTemplateTest
    {
        [Fact]
        public void Test_FindReplacement_Given_Single_Var_Finds_Single_Varname()
        {
            var template = new CodeTemplate { Content = "abcdef<<<<VAR1>>>>fedcba", Description = "Some Description", Id = "1" };

            var result = template.FindReplacements();

            Assert.Equal("VAR1", result[0].VarName);
        }

        [Fact]
        public void Test_FindReplacement_Given_Two_Vars_Finds_Two_Varnames()
        {
            var template = new CodeTemplate { Content = "abcdef<<<<VAR1>>>>fedcba abcdef<<<<VAR2>>>>fedcba", Description = "Some Description", Id = "1" };

            var result = template.FindReplacements();

            Assert.Equal("VAR1", result[0].VarName);
            Assert.Equal("VAR2", result[1].VarName);
        }

        [Fact]
        public void Test_FindReplacement_Given_No_Vars_Finds_No_Varnames()
        {
            var template = new CodeTemplate { Content = "public static void Main(String[] args)", Description = "Some Description", Id = "1" };

            var result = template.FindReplacements();

            Assert.Empty(result);
        }
    }
}
