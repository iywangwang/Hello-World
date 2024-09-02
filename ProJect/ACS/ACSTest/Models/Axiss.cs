using ACS.SPiiPlusNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ACSTest.Models
{
    class Axiss : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int AxisName = 0;

        public readonly Axis _axis = 0;

        private double _Velocity = 20;

        private double _Position = 0;

        private bool _IsMoveing = false;

        private bool _IsConnect = false;

        public Axiss(int name)
        {
            AxisName = name;
            _axis = (Axis)AxisName;            
        }

        public double Velocity
        {
            get => _Velocity;
            set
            {
                if (_Velocity == value) return;
                { 
                    _Velocity = Math.Round(value, 2);                    
                }
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Velocity"));
            }
        }

        public double Position
        {
            get => _Position;
            set
            {
                if (_Position == value) return;
                _Position = Math.Round(value, 2);
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Position"));
            }
        }

        public bool IsMoveing
        {
            get => _IsMoveing;
            set
            {
                if (_IsMoveing == value) return;
                _IsMoveing = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsMoveing"));
            }
        }

        public bool IsConnect
        {
            get => _IsConnect;
            set
            {
                if (_IsConnect == value) return;
                _IsConnect = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsConnect"));
            }
        }        
    }
}

