using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public class Onderneming : INotifyPropertyChanged
    {
        //var
        private string _adres;
        private string _naam;
        private string _soort;

        //prop
        public string Soort {
            get { return _soort; }
            set { _soort = value; RaisePropertyChanged("Soort"); }
        }


        public string Naam {
            get { return _naam; }
            set { _naam = value; RaisePropertyChanged("Naam"); }
        }


        public string Adres {
            get { return _adres; }
            set { _adres = value; RaisePropertyChanged("Adres"); }
        }

        //construct

        //method
        public event PropertyChangedEventHandler PropertyChanged; //bestand MVVM_INotifypropertyChanged snippet 3.Data
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
