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
	public partial class UserDataListPage : ContentPage
	{
        SQLiteManager<UserData> manager;
        UserData data = new UserData();
        public UserDataListPage ()
		{
			InitializeComponent ();
            List<UserData> data = new List<UserData>();
            manager = new SQLiteManager<UserData>();
            data = manager.GetAll().ToList();
            lstKullaniciData.BindingContext = data;
            lstKullaniciData.ItemTapped += LstKullaniciData_ItemTapped;

        }

        private async void LstKullaniciData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int? selectedId = null;
            if (lstKullaniciData.SelectedItem is UserData selectedUserData)
                selectedId = selectedUserData.Id;
            await Navigation.PushModalAsync(new NavigationPage(new InsertPage(selectedId)));
        }

        private async void MenuInsertItem_Activated(object sender, EventArgs e)
        {
            
            await Navigation.PushModalAsync(new NavigationPage(new InsertPage()));

        }

    }
}