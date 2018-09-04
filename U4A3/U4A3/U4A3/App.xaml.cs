using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using U4A3.Data;
using U4A3.Model;
using U4A3.View;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace U4A3
{
	public partial class App : Application
    {
        private static UserDatabase database;
		public static UserDatabase Database
		{
			get
			{
                // Initialises the database if it is null
                if (database == null)
					database = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.db3"));

				// Returns the database
				return database;
			}
		}

		private static HomeContentDatabase homeDatabase;
		public static HomeContentDatabase HomeDatabase
		{
			get
			{
				// Initialises the database if it is null
				if (homeDatabase == null)
					homeDatabase = new HomeContentDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Home.db3"));

				// Returns the database
				return homeDatabase;
			}
		}

		public App()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

		protected override void OnStart()
        {
            // Handle when your app starts
        }

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
