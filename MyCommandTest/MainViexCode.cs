using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyCommandTest
{
    class MainViexCode
    {
        public MyCommand ShowCommand { get; set; }

        public MainViexCode()
        {
            ShowCommand = new MyCommand(Show);
        }

        public void Show()
        {
            MessageBox.Show("Command 展示");
        }
    }
}
