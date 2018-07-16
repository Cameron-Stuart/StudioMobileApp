using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using U4A3.View;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace U4A3
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
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
