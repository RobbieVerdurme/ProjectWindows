using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using StadsApp_Windows.Model;
using StadsApp_Windows.Model.message;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace StadsApp_Windows.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public Gebruiker Gebruiker { get; set; }
        private string _username;
        public string Username {
            get {
                return _username;
            } 
            set {
                _username = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Username"));
            } }


        public MainPageViewModel()
        {
            Messenger.Default.Register<GebruikerLoggedInMessage>(this, (a) => ReceiveMessage(a));
            Messenger.Default.Register<GebruikerLoggedOffMessage>(this, (a) => ReceiveMessage(a));
            Username = "Login";
        }
        
        //Update the username if a new user is logged in
        private void ReceiveMessage(GebruikerLoggedInMessage m)
        {
            if (m.gebruiker == null) Username = "login";
            else
            {
                Username = m.gebruiker.Username;
                Gebruiker = m.gebruiker;
            }
        }

        //Update the username if the user logs off
        private void ReceiveMessage(GebruikerLoggedOffMessage m)
        {
            Username = "Login";
            Gebruiker = null;
        }

        //Notify the view of the changed username
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
