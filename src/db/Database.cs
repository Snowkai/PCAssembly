using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCAssembly.src.db.Models;

namespace PCAssembly.src.db
{
    class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _database.CreateTableAsync<PC>().Wait();
        }

        public Task<List<PC>> GetItemsAsync()
        {
            return _database.Table<PC>().ToListAsync();
        }

        public Task<int> SaveItemAsync(PC item)
        {
            if (item.Id != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(PC item)
        {
            return _database.DeleteAsync(item);
        }
    }
}
