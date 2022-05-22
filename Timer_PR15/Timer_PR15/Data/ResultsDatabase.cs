using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Timer_PR15.Models;

namespace Timer_PR15.Data
{
    public class ResultsDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ResultsDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Results>().Wait();
        }

        public Task<List<Results>> GetResultsAsync()
        {
            //Get all notes.
            return database.Table<Results>().ToListAsync();
        }

        public Task<Results> GetResultsAsync(int id)
        {
            // Get a specific note.
            return database.Table<Results>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveResultsAsync(Results res)
        {
            if (res.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(res);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(res);
            }
        }

        public Task<int> DeleteResultsAsync(Results res)
        {
            // Delete a note.
            return database.DeleteAsync(res);
        }
    }
}
