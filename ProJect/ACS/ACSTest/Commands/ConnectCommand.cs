using ACS.SPiiPlusNET;
using ACSTest.MainViewModel;
using ACSTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ACSTest.Commands
{
    class ConnectCommand : ICommand
    {
        public ConnectCommand(Func<Task> func1, Func<Task> func2)
        {
            _axisFunc = func1;
            _timerFunc = func2;
        }

        string AxisNum { get; set; }

        Func<Task> _axisFunc { get; set; }
        Func<Task> _timerFunc { get; set; }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                AxisNum = ModelACS.apiInstance.Transaction("?SYSINFO(13)");
            }
            catch (Exception)
            {
                MessageBox.Show("服务器未连接");
                return;
            }

            ModelACS.apiInstance.Enable(ACS.SPiiPlusNET.Axis.ACSC_AXIS_1);
            ModelACS.apiInstance.Enable(ACS.SPiiPlusNET.Axis.ACSC_AXIS_2);
            ModelACS.apiInstance.Enable(ACS.SPiiPlusNET.Axis.ACSC_AXIS_3);
            // 轴连接
            _axisFunc();
            _timerFunc();
        }
    }
}
