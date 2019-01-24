using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CodeGenerator.Extensions;
using System.Collections.ObjectModel;

namespace TestCodeGenerator
{
    public class ObservableCollectionExtensionTest
    {
        [Fact]
        public void Test_AsObservableCollection_Given_Collection_Returns_Matching_Collection()
        {
            var collection = new List<string>() { "s1", "s2", "s3" };
            var expected = new ObservableCollection<string>() { "s1", "s2", "s3" };

            var result = collection.AsObservableCollection();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_AsObservableCollection_Given_Empty_Collection_Returns_Empty_Observable()
        {
            var collection = new List<string>();
            var expected = new ObservableCollection<string>();

            var result = collection.AsObservableCollection();

            Assert.Equal(expected, result);
        }
    }
}
