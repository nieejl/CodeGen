using CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGenerator.Services
{
    public class MockDataStore : IDataStore<CodeTemplate>
    {
        List<CodeTemplate> items;

        public MockDataStore()
        {
            items = new List<CodeTemplate>();
            var mockItems = new List<CodeTemplate>
            {
                new CodeTemplate { Id = "1st", Description = "First item",
                    Content = "This is an item description. <<<<VAR1>>>> abcedekakgæl <<<<var2>>>> ajslkfdjsldkfjlk <<<<var3>>>> ajslkfdjsldkfjlk"},
                new CodeTemplate { Id = Guid.NewGuid().ToString(), Description = "Second item", Content="This is an item description." },
                new CodeTemplate { Id = Guid.NewGuid().ToString(), Description = "Third item", Content="This is an item description." },
                new CodeTemplate { Id = Guid.NewGuid().ToString(), Description = "Fourth item", Content="This is an item description." },
                new CodeTemplate { Id = Guid.NewGuid().ToString(), Description = "Fifth item", Content="This is an item description." },
                new CodeTemplate { Id = Guid.NewGuid().ToString(), Description = "Sixth item", Content="This is an item description." },
            };
            for (int i = 6; i < 30; i++)
            {
                mockItems.Add(new CodeTemplate { Id = Guid.NewGuid().ToString(), Description = $"Item number {i}", Content = "Description" });
            }
            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(CodeTemplate item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(CodeTemplate item)
        {
            var oldItem = items.Where((CodeTemplate arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((CodeTemplate arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<CodeTemplate> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CodeTemplate>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}