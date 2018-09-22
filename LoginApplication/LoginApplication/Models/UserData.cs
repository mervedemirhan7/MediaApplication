using Plugin.Geolocator.Abstractions;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LoginApplication.Models
{
    public class UserData : INotifyPropertyChanged
    {
        private string _boylam;
        private string _enlem;
        private string _aciklama;
       
        
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Enlem
        {
            get { return _enlem; }
            set
            {
                _enlem = value;
                OnPropertyChanged();
            }
        }
        public string Boylam
        {
            get { return _boylam; }
            set
            {
                _boylam = value;
                OnPropertyChanged();
            }
        }

        public string Aciklama
        {
            get { return _aciklama; }
            set
            {
                _aciklama = value;
                OnPropertyChanged();
            }
        }
        public byte[] Image { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
