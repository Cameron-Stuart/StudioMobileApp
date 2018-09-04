using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace U4A3.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();

            // Hides the add content button if the account is not a teacher
            if (App.Current.Properties.ContainsKey("teacher"))
                Button_AddContent.IsEnabled = true;
            else
                Button_AddContent.IsEnabled = false;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Set the List Views Items to all of the ToDoItems in the database
            ListView_HomeContent.ItemsSource = await App.HomeDatabase.GetAll();
        }

        private async void Button_AddContent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContent());
        }
    }
}