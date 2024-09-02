using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ACSTest.Commands
{
    class ResetCommand : ICommand
    {
        Func<string, Task> _func;

        public ResetCommand(Func<string, Task> func)
        {
            _func = func;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string obj = parameter as string;
            _func(obj);
        }
    }
}
