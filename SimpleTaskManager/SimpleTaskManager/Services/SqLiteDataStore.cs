using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTaskManager.Models;
using TxMobile.Storage.Services.Implementations;

namespace SimpleTaskManager.Services
{
    public class SqLiteDataStore : IDataStore<TaskModel>
    {
        readonly SqLiteDataProvider _dataProvider;

        public SqLiteDataStore(SqLiteDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<bool> AddItemAsync(TaskModel item)
        {
            await _dataProvider.AddOrUpdate(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            await _dataProvider.Remove<TaskModel>(id);
            return await Task.FromResult(true);
        }

        public async Task<TaskModel> GetItemAsync(Guid id)
        {
            return await _dataProvider.Select<TaskModel>(id);
        }

        public async Task<IEnumerable<TaskModel>> GetItemsAsync()
        {
            return await _dataProvider.SelectAll<TaskModel>();
        }

        public async Task<bool> UpdateItemAsync(TaskModel item)
        {
            await _dataProvider.AddOrUpdate(item);
            return await Task.FromResult(true);
        }
    }
}
