using IntelligentPlant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IntelligentPlant.Command
{
    class SwitchWorkShopCmd : ICommand
    {
        Action<int> myAction;

        public SwitchWorkShopCmd(Action<int> func)
        {
            myAction = func;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {            
            return true;
        }

        public void Execute(object? parameter)
        {
            int a = int.Parse(parameter.ToString());
            myAction(a);          
        }
    }
}
