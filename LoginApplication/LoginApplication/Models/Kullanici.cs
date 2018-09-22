using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LoginApplication.Models
{
    public class Kullanici
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TcNo { get; set; }
        public string Sifre { get; set; }
    }
}
