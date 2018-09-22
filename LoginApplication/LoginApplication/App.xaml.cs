using LoginApplication.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace LoginApplication
{
	public partial class App : Application
	{
        public static string DBName { get; set; } = "DemoDB.db3";
        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new UserDataListPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
