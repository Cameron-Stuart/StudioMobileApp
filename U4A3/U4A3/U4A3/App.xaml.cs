using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
					database = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3"));

				// Returns the database
				return database;
			}
		}

		public App()
		{
			InitializeComponent();

			MainPage = new Login();
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
