using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LoginApplication.Droid.Droid.Helper;
using LoginApplication.Helper;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly:Dependency (typeof (DroidConnection))]
namespace LoginApplication.Droid.Droid.Helper
{
    public class DroidConnection : MySQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            string DosyaYolu = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(DosyaYolu, App.DBName);
            var platform = new SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}