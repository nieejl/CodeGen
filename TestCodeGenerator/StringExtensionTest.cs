using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CodeGenerator.Extensions;

namespace TestCodeGenerator
{
    public class StringExtensionTest
    {
        [Fact]
        public void Test_IsMatchWithUnderscore_Given_Match_Returns_True()
        {
            string s1 = "_Hello";
            string s2 = "hello";

            bool result = s1.IsMatchWithUnderscore(s2);

            Assert.True(result);
        }

        [Fact]
        public void Test_IsMatchWithUnderscore_Given_Non_Match_Returns_False()
        {
            string s1 = "_Hello";
            string s2 = "hhello";

            bool result = s1.IsMatchWithUnderscore(s2);

            Assert.False(result);
        }

        [Fact]
        public void Test_IsEqualIgnoreCase_Given_Match_Returns_True()
        {
            string s1 = "Hello";
            string s2 = "hello";

            bool result = s1.IsEqualIgnoreCase(s2);

            Assert.True(result);
        }

        [Fact]
        public void Test_IsEqualIgnoreCase_Given_Non_Match_Returns_False()
        {
            string s1 = "Hello";
            string s2 = "hhello";

            bool result = s1.IsEqualIgnoreCase(s2);

            Assert.False(result);
        }
    }
}
