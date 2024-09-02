using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ACSTest.Commands
{
    class StartStraightMove : ICommand
    {
        Func<Task> _Func;

        public StartStraightMove(Func<Task> func)
        {
            _Func = func;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _Func();
        }
    }
}
