using LoginApplication.Helper;
using LoginApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApplication.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        SQLiteManager<Kullanici> manager = new SQLiteManager<Kullanici>();

        private Kullanici kullanici = new Kullanici();
		public LoginPage ()
		{
			InitializeComponent ();
            BindingContext = kullanici;

        }

        private async void girisButton_Clicked(object sender, EventArgs e)
        {
           
            int isInserted = manager.Insert(kullanici);

            if (isInserted > 0)
            {
                await DisplayAlert("Başarılı", "Giris Yapildi", "OK");
                await Navigation.PushModalAsync(new NavigationPage(new UserDataListPage()));
            }
            else
            {
                await DisplayAlert("Başarısız", "Giris Yapilamadi", "OK");
            }
        }
    }
}