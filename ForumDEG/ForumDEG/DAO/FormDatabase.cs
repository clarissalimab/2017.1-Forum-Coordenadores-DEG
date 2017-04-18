using ForumDEG.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumDEG.Utils
{
    public class FormDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public FormDatabase(string databasePath)
        {
            _database = new SQLiteAsyncConnection(databasePath);

            _database.CreateTableAsync<Form>().Wait();
        }

        public Task<List<Form>> GetAllForms()
        {
            return _database.Table<Form>().ToListAsync();
        }

        public Task<Form> GetForm(int id)
        {
            return _database.Table<Form>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveForm(Form newForm)
        {

            if (newForm.Id == 0)
            {
                return _database.InsertAsync(newForm);
            }
            else
            {
                return _database.UpdateAsync(newForm);
            }
        }

        public Task<int> DeleteForm(Form Form)
        {
            return _database.DeleteAsync(Form);
        }
    }
}
