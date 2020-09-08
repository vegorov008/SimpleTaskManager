using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleTaskManager.Models;

namespace SimpleTaskManager.Services
{
    public class MockDataStore : IDataStore<TaskModel>
    {
        readonly HashSet<TaskModel> items;

        public MockDataStore()
        {
            items = new HashSet<TaskModel>()
            {
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 1", Description="This is an item description." },
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 2", Description="This is an item description. This is an item description." },
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 3", Description="This is an item description. This is an item description. This is an item description." },
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 4", Description="This is an item description." },
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 5", Description="This is an item description. This is an item description. This is an item description. This is an item description." },
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 6", Description="This is an item description. This is an item description. This is an item description. This is an item description. This is an item description." },
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 7", Description="This is an item description." },
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 8", Description="This is an item description." },
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 9", Description="This is an item description." },
                new TaskModel { Id = Guid.NewGuid(), Title = "Task 10", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(TaskModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(TaskModel item)
        {
            items.RemoveWhere(x => x.Id == item.Id);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            items.RemoveWhere(x => x.Id == id);

            return await Task.FromResult(true);
        }

        public async Task<TaskModel> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<TaskModel>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
    }
}