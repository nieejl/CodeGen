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

        public CodeTemplate CreateTwoVariableTemplate()
        {
            return new CodeTemplate
            {
                Content =
                "public static void Main(String[] args) {\n" +
                "\t<<<<var1>>>>=2;\n" +
                "\t<<<<var2>>>>=3;\n" +
                "\treturn <<<<var1>>>>+<<<<var2>>>>;\n}",
                Id = "1",
                Description = "Placeholder description"
            };
        }

        public CodeTemplate CreateOneVariableGeneration()
        {
            return new CodeTemplate
            {
                Content =
                "public static void Main(String[] args) {\n" +
                "\tval1=2;\n" +
                "\t<<<<var2>>>>=3;\n" +
                "\treturn val1+<<<<var2>>>>;\n}",
                Id = "1",
                Description = "Placeholder description"
            };
        }

        public CodeTemplate CreateTwoVariableGeneration()
        {
            return new CodeTemplate
            {
                Content =
                "public static void Main(String[] args) {\n" +
                "\tval1=2;\n" +
                "\tval2=3;\n" +
                "\treturn val1+val2;\n}",
                Id = "1",
                Description = "Placeholder description"
            };
        }

        (CodeTemplate, CodeTemplate, List<Replacement>) CreateGenerationPair (
            string var1="val1", string var2="val2")
        {
            var template = CreateTwoVariableTemplate();
            var replacements = new List<Replacement>
            {
                new Replacement { VarName = "var1", VarValue=var1},
                new Replacement { VarName = "var2", VarValue=var2}
            };

            CodeTemplate expected =
                (var1 == "val1" && var2 == "val2") ? CreateTwoVariableGeneration() :
                (var1 == "val1" && var2 == null) ? CreateOneVariableGeneration() :
                template;
            return (template, expected, replacements);
        }

        [Fact]
        public void Test_GenerateContent_Given_No_Var_Text_Returns_Original_text()
        {
            (var template, var generation, var replacements) = CreateGenerationPair();
            //var template = new CodeTemplate { Content = "public static void Main(String[] args)", Description = "Some Description", Id = "1" };

            var result = template.GenerateContent(new List<Replacement>());

            Assert.Equal(template.Content, result);
        }


        [Fact]
        public void Test_GenerateContent_Given_Two_Vars_And_Text_Replaces_Two_Vars()
        {
            (var template, var generation, var replacements) = CreateGenerationPair();

            var result = template.GenerateContent(replacements);

            Assert.Equal(generation.Content, result);
        }

        [Fact]
        public void Test_GenerateContent_Given_One_Var_Text_Replaces_One_Var()
        {
            (var template, var generation, var replacements) = CreateGenerationPair("val1", null);

            var result = template.GenerateContent(replacements);

            Assert.Equal(generation.Content, result);
        }

        [Fact]
        public void Test_GenerateContent_Given_Null_Vars_Returns_Original_Text()
        {
            (var template, var generation, var replacements) = CreateGenerationPair(null, null);
            replacements = new List<Replacement> { null, null };

            var result = template.GenerateContent(replacements);

            Assert.Equal(generation.Content, result);
        }
    }
}
