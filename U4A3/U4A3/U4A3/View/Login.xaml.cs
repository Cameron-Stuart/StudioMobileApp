using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using U4A3.Data;
using U4A3.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace U4A3.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent ();
		}
		
		private async void Button_Login_Clicked(object sender, EventArgs e)
		{
			// Checks if username and password textboxes are not empty
			if (Entry_Username.Text != "" && Entry_Password.Text != "")
			{
				// Creates new User with username and password that the user entered on the login screen
				User user = new User()
				{
					Username = Entry_Username.Text,
					Password = Entry_Password.Text
				};

				// Returns a list of the entire database
				List<User> DBReturn = await App.Database.GetAll();

				// For every item in the list
				foreach (User item in DBReturn)
				{
					// If the username and passwords match between the database and user input
					if (item.Username == user.Username && item.Password == user.Password)
					{
						// Checks if the account name, username and type properties are alread stores
						// If either exists, it will delete them
						if (App.Current.Properties.ContainsKey("account_type"))
							App.Current.Properties.Remove("account_type");
						if (App.Current.Properties.ContainsKey("account_name"))
							App.Current.Properties.Remove("account_name");
						if (App.Current.Properties.ContainsKey("account_username"))
							App.Current.Properties.Remove("account_username");

						// Save the user account type, name and username based on what is stored in the database (will be used later)
						App.Current.Properties.Add("account_type", item.Type);
						App.Current.Properties.Add("account_name", item.Name);
						App.Current.Properties.Add("account_username", user.Username);

						// Changes the current page
						// TODO: Change to home page
						App.Current.MainPage = new UserTest();
					}
					else
					{
						// If it doesn't redirect away, login has failed
						await DisplayAlert("Login failed", "Please check that your username and password are correct and try again", "OK");
					}
				}
			}
			else
			{
				// If the username is blank...
				if (Entry_Username.Text == "")
					// Display an error message saying to enter a username
					Label_UsernameError.Text = "Please enter your username";
				// If the password is blank...
				if (Entry_Password.Text == "")
					// Display an error message saying to enter a password
					Label_PasswordError.Text = "Please enter your password";
			}
		}

		private void Button_Register_Clicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new Register();
		}

		private void Button_PassReset_Clicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new UserTest();
		}
	}
}