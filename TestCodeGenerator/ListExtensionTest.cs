using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGenerator.Extensions;
using Xunit;

namespace TestCodeGenerator
{
    public class ListExtensionTest
    {
        [Fact]
        public void Test_RemoveDuplicates_Given_List_Returns_List_Without_Duplicates()
        {
            var list = new List<string>() { "s1", "s2", "s3", "s1" };
            var expected = new List<string>() { "s1", "s2", "s3" };

            var result = list.UnorderedRemoveDuplicates();

            var listsEqual = !result.Except(expected).Any() && !expected.Except(result).Any();
            Assert.True(result.Count == expected.Count && listsEqual);
        }

        [Fact]
        public void Test_IsEqualTo_List_Given_Equal_Returns_True()
        {
            var firstList = new List<string>() { "s1", "s2", "s3" };
            var secondList = new List<string>() { "s1", "s2", "s3" };

            var result = firstList.IsEqualTo(secondList);

            Assert.True(result);
        }

        [Fact]
        public void Test_IsEqualTo_List_Given_List_Missing_Element_Returns_False()
        {
            var firstList = new List<string>() { "s1", "s2" };
            var secondList = new List<string>() { "s1", "s2", "s3" };

            var result = firstList.IsEqualTo(secondList);

            Assert.False(result);
        }

        [Fact]
        public void Test_IsEqualTo_List_Given_List_Missing_Duplicate_Returns_False()
        {
            var firstList = new List<string>() { "s1", "s2", "s2", "s3" };
            var secondList = new List<string>() { "s1", "s2", "s3" };

            var result = firstList.IsEqualTo(secondList);

            Assert.False(result);
        }

        [Fact]
        public void Test_IsEqualTo_List_Given_List_With_Different_Duplicate_Returns_False()
        {
            var firstList = new List<string>() { "s1", "s2", "s2", "s3" };
            var secondList = new List<string>() { "s1", "s2",      "s3", "s3" };

            var result = firstList.IsEqualTo(secondList);

            Assert.False(result);
        }
    }
}
