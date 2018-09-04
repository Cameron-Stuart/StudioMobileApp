using SQLite;
using System.Collections.Generic;
using U4A3.Model;
using System.Threading.Tasks;

namespace U4A3.Data
{
	/// <summary>
	/// Database storing user information
	/// </summary>
    public class UserDatabase
    {
		// New readonly asynchronous database connection
		readonly SQLiteAsyncConnection database;

		public UserDatabase(string Path)
		{
			database = new SQLiteAsyncConnection(Path);

            database.CreateTableAsync<User>().Wait();
		}

		// Insert user information into the database
		public Task Insert(User Item)
		{
			return database.InsertAsync(Item);
		}

		// Get all user information
		public Task<List<User>> GetAll()
		{
			return database.Table<User>().ToListAsync();
		}
    }
}
