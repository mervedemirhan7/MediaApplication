using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApplication.Converter;
using LoginApplication.Helper;
using LoginApplication.Models;
using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPage : ContentPage
    {

        SQLiteManager<UserData> manager = new SQLiteManager<UserData>();

        private UserData data = new UserData();

        public InsertPage(int? id = null)
        {

            InitializeComponent();
            if (id.HasValue)
            {
                data = manager.Get(id.Value);

            }
            btnGetLocation.Clicked += BtnGetLocation_Clicked;
            BindingContext = data;
            lblLat.SetBinding(Label.TextProperty, "Enlem");
            lblLong.SetBinding(Label.TextProperty, "Boylam");
            lblAciklama.SetBinding(Entry.TextProperty, "Aciklama");
            image.SetBinding(Image.SourceProperty, "Image", BindingMode.TwoWay, new ByteToImageFieldConverter());

        }
        private async void BtnGetLocation_Clicked(object sender, EventArgs e)
        {

            await GetLocation();

            if (GetLocation() != null)
            {
                await DisplayAlert("Location", "Konum Bilgisi Alındı", "OK");

            }

        }

        private async Task GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();
            data.Enlem = position.Latitude.ToString();
            data.Boylam = position.Longitude.ToString();

        }

        private async void btnTake_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Seçim Yapınız", "Cıkıs", "", "Fotoğraf Çek", "Fotoğraf Yükle");
            if (action == "Fotoğraf Çek")
            {
                FotografCek();


            }
            else if (action == "Fotoğraf Yükle")
            {
                FotografYükle();
            }
        }

        private async void FotografYükle()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("HATA", "Fotoğraf seçme desteklenmiyor", "OK");
            }


            var file = await CrossMedia.Current.PickPhotoAsync(); // Seçtiğim fotoğrafı file değişkenine veriyorum

            if (file == null)
            {
                return;
            }
            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();

                file.Dispose();
                return stream;



            });


        }

        private async void FotografCek()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("HATA", "Kamera aktif değil", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MediaPlugin",
                Name = DateTime.Now + "jpg",
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
            });
            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {

            int isInserted = data.Id > 0 ? manager.Update(data) : manager.Insert(data);
            if (isInserted > 0)
            {
                await DisplayAlert("Başarılı", "Kayit Yapildi", "OK");
                await Navigation.PushModalAsync(new NavigationPage(new UserDataListPage()));
            }
            else
            {
                await DisplayAlert("Başarısız", "Kayit Yapilamadi", "OK");
            }
        }
    }
}
