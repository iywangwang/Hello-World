using MVVM_CommandText.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_CommandText.ViewModels
{
    class ManWindowViewModel
    {
        public ManWindowViewModel()
        {
            this.FillCommand = new FillCommand();
            this.ClearCommand = new ClearCommand();
        }

        public ICommand FillCommand { get; set; }
        public ICommand ClearCommand { get; set;}
    }
}
