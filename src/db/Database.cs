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
        private SQLiteAsyncConnection _database;

        async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await _database.CreateTableAsync<PC>();
        }

        public async Task<List<PC>> GetItemsAsync()
        {
            await Init();
            return await _database.Table<PC>().ToListAsync();
        }
        public async Task<PC> GetItemAsync(int id)
        {
            await Init();
            return await _database.Table<PC>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        public async Task<int> SaveItemAsync(PC item)
        {
            await Init();
            if (item.Id != 0)
            {
                return await _database.UpdateAsync(item);
            }
            else
            {
                return await _database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(PC item)
        {
            await Init();
            return await _database.DeleteAsync(item);
        }
    }
}
