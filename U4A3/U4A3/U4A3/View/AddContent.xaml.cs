using System;
using System.Linq;

using U4A3.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace U4A3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContent : ContentPage
    {
        public AddContent()
        {
            InitializeComponent();
        }

		private async void Button_Add_Clicked(object sender, EventArgs e)
		{
			if (Entry_Title.Text != "" || Entry_Content.Text != "")
			{
				HomeContent content = new HomeContent()
				{
					Title = Entry_Title.Text,
					Content = Entry_Content.Text
				};

				await App.HomeDatabase.Insert(content);
                await Navigation.PopAsync();
			}
			else
			{
				await DisplayAlert("Error", "Please make sure that the title entry and the content entry are not empty", "OK");
			}
		}
	}
}