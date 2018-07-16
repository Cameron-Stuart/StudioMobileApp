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
						// Display login successful message
						// TODO: Remove alert
						await DisplayAlert("Login successful", "Login succeeeded", "Great!");
						// Changes the current page
						// TODO: Change to home page
						App.Current.MainPage = new UserTest();
					}
				}

				// If it doesn't redirect away, login has failed
				await DisplayAlert("Login failed", "Please check that your username and password are correct and try again", "OK");
			}
			else
			{
				if (Entry_Username.Text == "")
					Label_UsernameError.Text = "Please enter your username";
				if (Entry_Password.Text == "")
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