using SQLite;

namespace U4A3.Model
{
	/// <summary>
	/// Data type for storing user information in the database
	/// </summary>
    public class User
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Type { get; set; }
	}
}
