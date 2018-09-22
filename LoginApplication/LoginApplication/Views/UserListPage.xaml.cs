using LoginApplication.Helper;
using LoginApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApplication.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserListPage : ContentPage
	{
        SQLiteManager<Kullanici> manager;
        
        //Kullanici k=new Kullanici();
		public UserListPage ()
		{
			InitializeComponent ();
            List<Kullanici> liste = new List<Kullanici>();

            manager = new SQLiteManager<Kullanici>();
            liste = manager.GetAll().ToList();
            lstKullanicilar.BindingContext = liste;

                  
        }

        private void onMenuDelete(object sender, EventArgs e)
        {
            var selectedMenuItem = (MenuItem)sender;
            int isDeleted = manager.Delete(Convert.ToInt32(selectedMenuItem.CommandParameter.ToString()));

            if (isDeleted > 0)
            {
                DisplayAlert("Başarılı", "Silindi", "OK");
                RefreshData();
            }
            else
            {
                DisplayAlert("Başarısız", "Silinemedi", "OK");
            }

        }

        private void RefreshData()
        {
            List<Kullanici> liste = new List<Kullanici>();
            liste = manager.GetAll().ToList();
            lstKullanicilar.BindingContext = liste;
        }

        
    }
}