using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyCommandTest
{
    class MyCommand : ICommand
    {
        Action _actin;
        public MyCommand(Action action) 
        {
            _actin = action;
        }
        
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _actin();
        }
    }
}
