using SQLite;
using System.Collections.Generic;
using U4A3.Model;
using System.Threading.Tasks;

namespace U4A3.Data
{
	/// <summary>
	/// Database storing user information
	/// </summary>
	public class HomeContentDatabase
	{
		// New readonly asynchronous database connection
		readonly SQLiteAsyncConnection database;

		public HomeContentDatabase(string Path)
		{
			database = new SQLiteAsyncConnection(Path);

			database.CreateTableAsync<HomeContent>().Wait();
		}

		// Insert user information into the database
		public Task Insert(HomeContent Item)
		{
			return database.InsertAsync(Item);
		}

		// Get all user information
		public Task<List<HomeContent>> GetAll()
		{
			return database.Table<HomeContent>().ToListAsync();
		}
	}
}
