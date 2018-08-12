using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using U4A3.Model;
using U4A3.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace U4A3.View.Temp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContent : ContentPage
	{
		public AddContent ()
		{
			InitializeComponent ();

			if (!App.Current.Properties.Values.ToArray().Contains("Teacher"))
			{
				App.Current.MainPage = new Login();
			}
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Set the List Views Items to all of the ToDoItems in the database
			LVDisplayContent.ItemsSource = await App.Database.GetAll();
		}

		private async void Button_Add_Clicked(object sender, EventArgs e)
		{
			if (Entry_Title.Text != "" && Entry_Content.Text != "")
			{
				HomeContent content = new HomeContent()
				{
					Title = Entry_Title.Text,
					Content = Entry_Content.Text
				};

				await App.HomeDatabase.Insert(content);
				App.Current.MainPage = new Login();
			}
			else
			{
				await DisplayAlert("Oopsy-whoopsy", "We made a fucky-wucky. One of our code-monkeys is working vewy hard to fix this isse", "Cancel");
			}
		}
	}
}