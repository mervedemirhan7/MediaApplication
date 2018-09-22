using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginApplication.Helper
{
    public interface MySQLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}
