using ACS.SPiiPlusNET;
using ACSTest.Commands;
using ACSTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace ACSTest.MainViewModel
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            myTimer = new System.Timers.Timer(50);

            _ConnectCommand = new ConnectCommand(Open_IsAxisConnect, Open_Timer);

            _StopConnectCommand = new StopConnectCommand(Close_IsAxisConnect, Close_Timer);
            
            _StartDotMotionCommand = new StartDotMotionCommand(StartMoveAxis);

            _StopMoveAxisCommand = new StopMoveAxisCommand(StopMoveAxis);

            _ResetCommand = new ResetCommand(ResetAxis);

            EtherentInstance = Etherent.EtherentInstance;

            AxisList = new List<Axiss> { new Axiss(1), new Axiss(2), new Axiss(3) };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Etherent EtherentInstance { get; set; }

        System.Timers.Timer myTimer;

        public static bool IsConnected = false;

        private bool _RelativeMove = true;
        public bool RelativeMove
        {
            get => _RelativeMove;
            set
            {
                if (_RelativeMove == value) return;
                _RelativeMove = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("RelativeMove"));
            }
        }

        private bool _AbsoluteMove = false;
        public bool AbsoluteMove
        {
            get => _AbsoluteMove;
            set
            {
                if (_AbsoluteMove == value) return;
                _AbsoluteMove = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("AbsoluteMove"));
            }
        }

        private bool _IsAxisConnect = false;
        public bool IsAxisConnect
        {
            get => _IsAxisConnect;
            set
            {
                if (_IsAxisConnect == value) return;
                _IsAxisConnect = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsAxisConnect"));
            }
        }

        private List<Axiss> _AxisList = new List<Axiss>();
        public List<Axiss> AxisList
        {
            get => _AxisList;
            set
            {
                if (_AxisList == value) return;
                _AxisList = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("AxisList"));
            }
        }

        private string _Position { get; set; } = "(0, 0, 0)";
        public string Position
        {
            get => _Position;
            set
            {
                if (_Position == value) return;
                _Position = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Position"));
            }
        }

        public ConnectCommand _ConnectCommand { get; set; }

        public StopConnectCommand _StopConnectCommand { get; set; }

        public StartDotMotionCommand _StartDotMotionCommand { get; set; }

        public StopMoveAxisCommand _StopMoveAxisCommand { get; set; }

        public ResetCommand _ResetCommand { get; set; }

        private Task Open_IsAxisConnect()
        {
            return Task.Run(() =>
            {
                AxisList[0].IsConnect = true;
                AxisList[1].IsConnect = true;
                AxisList[2].IsConnect = true;
                IsAxisConnect = true;
            });
        }

        private Task Close_IsAxisConnect()
        {
            return Task.Run(() =>
            {
                AxisList[0].IsConnect = false;
                AxisList[1].IsConnect = false;
                AxisList[2].IsConnect = false;
                IsAxisConnect = false;
            });
        }

        private Task Open_Timer()
        {
            return (Task)Task.Run(() =>
            {
                foreach (var axis in AxisList)
                {
                    ModelACS.apiInstance.SetVelocity(axis._axis, axis.Velocity);
                }

                myTimer.Start();
                myTimer.Elapsed += OnTimedEvent;                
            });
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            if (this.IsAxisConnect == false) return;
            foreach (var axis in AxisList)
            {
                //axis.Velocity = ModelACS.apiInstance.GetVelocity(axis._axis);
                axis.Position = ModelACS.apiInstance.GetFPosition(axis._axis);

                ChangPosition();
            }
        }

        private Task Close_Timer()
        {
            //Task.Delay(TimeSpan.FromSeconds(5));
            return (Task)Task.Run(() =>
            {                
                myTimer.Stop();
            });
        }

        private void ChangPosition()
        {
            this.Position = $"({AxisList[0].Position}, {AxisList[1].Position}, {AxisList[2].Position})";
        }

        private Task StartMoveAxis(string name)
        {

            return (Task)Task.Run(() =>
            {
                if (IsAxisConnect == false) return;

                foreach (var axis in AxisList)
                {
                    ModelACS.apiInstance.SetVelocity(axis._axis, axis.Velocity);
                }

                switch (name)
                {
                    case "x":
                        ModelACS.apiInstance.WaitMotorEnabled(AxisList[0]._axis, 1, 5000);
                        ModelACS.apiInstance.Jog(MotionFlags.ACSC_AMF_VELOCITY, AxisList[0]._axis, AxisList[0].Velocity);
                        AxisList[0].IsMoveing = true;
                        break;
                    case "y":
                        ModelACS.apiInstance.WaitMotorEnabled(AxisList[1]._axis, 1, 5000);
                        ModelACS.apiInstance.Jog(MotionFlags.ACSC_AMF_VELOCITY, AxisList[1]._axis, AxisList[1].Velocity);
                        AxisList[1].IsMoveing = true;
                        break;
                    case "z":
                        ModelACS.apiInstance.WaitMotorEnabled(AxisList[2]._axis, 1, 5000);
                        ModelACS.apiInstance.Jog(MotionFlags.ACSC_AMF_VELOCITY, AxisList[2]._axis, AxisList[2].Velocity);
                        AxisList[2].IsMoveing = true;
                        break;
                    case "-x":
                        ModelACS.apiInstance.WaitMotorEnabled(AxisList[0]._axis, 1, 5000);
                        ModelACS.apiInstance.Jog(MotionFlags.ACSC_AMF_VELOCITY, AxisList[0]._axis, -AxisList[0].Velocity);
                        AxisList[0].IsMoveing = true;
                        break;
                    case "-y":
                        ModelACS.apiInstance.WaitMotorEnabled(AxisList[1]._axis, 1, 5000);
                        ModelACS.apiInstance.Jog(MotionFlags.ACSC_AMF_VELOCITY, AxisList[1]._axis, -AxisList[1].Velocity);
                        AxisList[1].IsMoveing = true;
                        break;
                    case "-z":
                        ModelACS.apiInstance.WaitMotorEnabled(AxisList[2]._axis, 1, 5000);
                        ModelACS.apiInstance.Jog(MotionFlags.ACSC_AMF_VELOCITY, AxisList[2]._axis, -AxisList[2].Velocity);
                        AxisList[2].IsMoveing = true;
                        break;
                    default:
                        break;
                }
            });            
        }

        private Task StopMoveAxis(string name)
        {
            return (Task)Task.Run(() => {
                if (IsAxisConnect == false) return;
                switch (name)
                {
                    case "x":
                        ModelACS.apiInstance.Kill(AxisList[0]._axis);
                        AxisList[0].IsMoveing = false;
                        break;
                    case "y":
                        ModelACS.apiInstance.Kill(AxisList[1]._axis);
                        AxisList[1].IsMoveing = false;
                        break;
                    case "z":
                        ModelACS.apiInstance.Kill(AxisList[2]._axis);
                        AxisList[2].IsMoveing = false;
                        break;
                    case "-x":
                        ModelACS.apiInstance.Kill(AxisList[0]._axis);
                        AxisList[0].IsMoveing = false;
                        break;
                    case "-y":
                        ModelACS.apiInstance.Kill(AxisList[1]._axis);
                        AxisList[1].IsMoveing = false;
                        break;
                    case "-z":
                        ModelACS.apiInstance.Kill(AxisList[2]._axis);
                        AxisList[2].IsMoveing = false;
                        break;
                    default:
                        break;
                }
            });            
        }

        private Task ResetAxis(string name)
        {
            return (Task)Task.Run(() => {
                if (IsAxisConnect == false) return;
                switch (name)
                {
                    case "x":
                        ModelACS.apiInstance.Kill(AxisList[0]._axis);
                        ModelACS.apiInstance.SetFPosition(AxisList[0]._axis, 0);
                        AxisList[0].IsMoveing = false;
                        break;
                    case "y":
                        ModelACS.apiInstance.Kill(AxisList[1]._axis);
                        ModelACS.apiInstance.SetFPosition(AxisList[1]._axis, 0);
                        AxisList[1].IsMoveing = false;
                        break;
                    case "z":
                        ModelACS.apiInstance.Kill(AxisList[2]._axis);
                        ModelACS.apiInstance.SetFPosition(AxisList[2]._axis, 0);
                        AxisList[2].IsMoveing = false;
                        break;
                    default:
                        foreach (var axis in AxisList) {
                            ModelACS.apiInstance.Kill(axis._axis);
                            ModelACS.apiInstance.SetFPosition(axis._axis, 0);
                        }
                        break;
                }
            });            
        }
    }
}