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

		private void Button_Login_Clicked(object sender, EventArgs e)
		{
			// TODO: Fix error messages and add login code
			if (Entry_Username.Text == "")
			{
				// Label_ErrorUsername.Text = "Enter a username";
			}
			if (Entry_Password.Text == "")
			{
				// Label_ErrorPassword.Text = "Enter a password";
			}
		}

		private void Button_Register_Clicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new Register();
		}

		private void Button_PassReset_Clicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new Register();
		}
	}
}