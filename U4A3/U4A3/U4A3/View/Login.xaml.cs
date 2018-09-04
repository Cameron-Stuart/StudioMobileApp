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
        public User CurrentUser;

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
                        if (App.Current.Properties.ContainsKey("teacher"))
                            App.Current.Properties.Remove("teacher");
						// Creates a key if the user is a teacher
						if (item.Type == "Teacher")
							App.Current.Properties.Add("teacher", "Teacher");

                        // TEMP
                        CurrentUser = new User
                        {
                            Name = item.Name,
                            Type = item.Type
                        };


                        // Changes the current page
                        NavPush();
                    }
                }

                // If the username is blank...
                if (Entry_Username.Text == "")
                    // Display an error message saying to enter a username
                    Label_UsernameError.Text = "Please enter your username";
                // If the password is blank...
                if (Entry_Password.Text == "")
                    // Display an error message saying to enter a password
                    Label_PasswordError.Text = "Please enter your password";
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

        private async void NavPush()
        {
            await Navigation.PushAsync(new Home());
        }

		private async void Button_Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
	}
}