using LoginApplication.Helper;
using LoginApplication.UWP.WinPhone.Helper;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(WinConnection))]
namespace LoginApplication.UWP.WinPhone.Helper
{
    public class WinConnection : MySQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            var path = System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path,
    LoginApplication.App.DBName);
            var platform = new SQLitePlatformWinRT();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}
