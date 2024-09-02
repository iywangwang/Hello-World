using ACS.SPiiPlusNET;
using ACSTest.MainViewModel;
using ACSTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ACSTest.Commands
{
    class StopConnectCommand : ICommand
    {
        MotorStates motorStates;

        public StopConnectCommand(Func<Task> func1, Func<Task> func2)
        {
            _axisFunc = func1;
            _timerFunc = func2;
        }

        public event EventHandler? CanExecuteChanged;

        Func<Task> _axisFunc { get; set; }
        Func<Task> _timerFunc { get; set; }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (ModelACS.apiInstance.GetMotorState(ACS.SPiiPlusNET.Axis.ACSC_AXIS_1) == (MotorStates)4194320)
            {
                MessageBox.Show("轴未连接");
                return;
            }

            ModelACS.apiInstance.Halt(ACS.SPiiPlusNET.Axis.ACSC_AXIS_1);
            ModelACS.apiInstance.Halt(ACS.SPiiPlusNET.Axis.ACSC_AXIS_2);
            ModelACS.apiInstance.Halt(ACS.SPiiPlusNET.Axis.ACSC_AXIS_3);
            
            ModelACS.apiInstance.DisableAll();

            _axisFunc();
            _timerFunc();
        }
    }
}
