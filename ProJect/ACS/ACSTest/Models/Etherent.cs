using ACS.SPiiPlusNET;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ACSTest.Models
{
    internal class Etherent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _Prot = "701";

        public string Prot
        {
            get { return _Prot; }
            set
            {
                if (_Prot == value) return;
                _Prot = value;

                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Prot"));
            }
        }

        private string _ip = "127.0.0.1";

        public string Ip
        {
            get { return _ip; }
            set
            {
                if (_ip == value) return;
                {
                    var regex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
                    bool isValidIP;
                    if ( isValidIP = regex.IsMatch(value))
                        _ip = value; 
                    else
                    {
                        return;
                    }
                }

                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Ip"));
            }
        }

        private Etherent() { }

        private static Etherent etherentInstance = null;

        public static Etherent EtherentInstance
        {
            get
            {
                if (etherentInstance == null)
                    etherentInstance= new Etherent();
                return etherentInstance;
            }
        }
    }
}
