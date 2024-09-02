using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ACSTest.Commands
{
    class StartDotMotionCommand : ICommand
    {
        Func<string, Task> _func;

        public StartDotMotionCommand(Func<string, Task> func)
        {
            _func = func;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            //var obj = parameter as Button;
            //if (obj.MouseLeftButtonDown == null)
            return true;
        }

        public void Execute(object? parameter)
        {
            string obj = parameter as string;
            _func(obj);
        }
    }
}
