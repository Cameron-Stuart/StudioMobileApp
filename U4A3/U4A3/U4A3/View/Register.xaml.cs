﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using U4A3.Data;
using U4A3.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace U4A3.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
		StringBuilder ErrorBuilder = new StringBuilder();

		public Register ()
		{
			InitializeComponent ();
		}

		private async void Button_Register_Clicked(object sender, EventArgs e)
		{
			if (Entry_Name.Text != ""
				&& Entry_Username.Text != ""
				&& Entry_Password.Text != ""
				&& Entry_Email.Text != ""
				&& Picker_Type.SelectedIndex != -1)
			{
				User user = new User()
				{
					Name = Entry_Name.Text,
					Username = Entry_Username.Text,
					Email = Entry_Email.Text,
					Password = Entry_Password.Text,
					Type = Picker_Type.Items[Picker_Type.SelectedIndex]
				};

				List<User> DB = await App.Database.GetAll();

				if (DB.Count == 0)
				{
					await App.Database.Insert(user);
                    await Navigation.PushAsync(new Login());
                }
				else
				{
					foreach (User item in DB)
					{
						if (item.Username == user.Username)
							await DisplayAlert("Registration failed", "This email is already in use, please use another", "OK");
						else if (item.Email == user.Email)
							await DisplayAlert("Registration failed", "This email is already in use, please use another", "OK");
						else
						{
                            Insert(user);
						}
					}
				}
			}
			else
			{
				if (Entry_Name.Text == "")
					Label_NameError.Text = "Please enter your name";
				if (Entry_Username.Text == "")
					Label_UsernameError.Text = "Please enter a username";
				if (Entry_Password.Text == "")
					Label_PasswordError.Text = "Please enter a password";
				if (Entry_Email.Text == "")
					Label_EmailError.Text = "Please enter your email";
				if (Entry_Email.Text != "" && Regex.IsMatch(Entry_Email.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
					Label_EmailError.Text = "Please enter a valid email";
				if (Picker_Type.SelectedIndex == -1)
					Label_TypeError.Text = "Please select an account type";
				await DisplayAlert("Registration failed", "Unknown error", "OK");
			}
		}

        async void Insert(User user)
        {
            await App.Database.Insert(user);
            await Navigation.PopAsync();
        }

		private void Button_Login_Clicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new Login();
		}
	}
}