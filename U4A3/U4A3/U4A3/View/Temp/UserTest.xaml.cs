using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace U4A3.View.Temp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserTest : ContentPage
	{
		public UserTest ()
		{
			InitializeComponent ();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Set the List Views Items to all of the ToDoItems in the database
			LVToDo.ItemsSource = await App.Database.GetAll();
		}
	}
}