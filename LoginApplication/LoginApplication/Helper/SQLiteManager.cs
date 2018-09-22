using LoginApplication.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace LoginApplication.Helper
{
   public class SQLiteManager<T> where T:class
    {
        SQLiteConnection sqlConnection;

        public SQLiteManager()
        {
            sqlConnection = DependencyService.Get<MySQLiteConnection>().GetConnection();

            sqlConnection.CreateTable<T>();
           
        }

        public int Insert(T model)
        {
            return sqlConnection.Insert(model);
        }
        public int Update(T model)
        {
            return sqlConnection.Update(model);
        }
        public int Delete(int Id)
        {
            return sqlConnection.Delete<T>(Id);  
        }
        public IEnumerable<T> GetAll()
        {
            return sqlConnection.Table<T>();
        }
        public UserData Get(int Id)
        {
            return sqlConnection.Table<UserData>().Where(x => x.Id == Id).FirstOrDefault();
           
        }
        public void Dispose()
        {
            sqlConnection.Dispose();
        }
        public void DeleteAll()
        {
            sqlConnection.DeleteAll<T>();
        }
    }
}
