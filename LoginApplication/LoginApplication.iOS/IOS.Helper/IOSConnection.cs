using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using LoginApplication.Helper;
using LoginApplication.iOS.IOS.Helper;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency (typeof(IOSConnection))]
namespace LoginApplication.iOS.IOS.Helper
{
    public class IOSConnection : MySQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            string DosyaYolu = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(DosyaYolu, App.DBName);
            var platform = new SQLitePlatformIOS();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}