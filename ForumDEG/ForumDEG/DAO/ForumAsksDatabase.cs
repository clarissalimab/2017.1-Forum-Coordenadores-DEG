using ForumDEG.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumDEG.DAO
{
    class ForumAsksDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ForumAsksDatabase(string databasePath)
        {
            _database = new SQLiteAsyncConnection(databasePath);

            _database.CreateTableAsync<FormAsks>().Wait();
        }

        public Task<List<FormAsks>> GetAllAsksFromForm(int FormId)
        {
            return _database.Table<FormAsks>().ToListAsync();
        }

        public Task<FormAsks> GetAsk(int id)
        {
            return _database.Table<FormAsks>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveForum(FormAsks newAsk)
        {

            if (newAsk.Id == 0)
            {
                return _database.InsertAsync(newAsk);
            }
            else
            {
                return _database.UpdateAsync(newAsk);
            }
        }

        public Task<int> DeleteAsk(FormAsks Ask)
        {
            return _database.DeleteAsync(Ask);
        }
    }
}
