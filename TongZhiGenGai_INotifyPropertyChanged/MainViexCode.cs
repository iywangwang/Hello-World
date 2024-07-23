using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TongZhiGenGai_INotifyPropertyChanged
{
    class MainViexCode : ViexCodelBase
    {
        public MainViexCode()
        {
            Name = "Hello";
            ShowCommand = new MyCommand(Show);
        }

        public MyCommand ShowCommand { get; set; }

        private string name;
        public string Name {
            get 
            {
                return name;
            } set 
            {
                name = value;
               //OnPropertyChanged("Name");
               OnPropertyChanged();
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                //OnPropertyChanged("Title");
                OnPropertyChanged();
            }
        }

        public void Show()
        {
            Title = "显示标题";
            Name = "点击了按钮";
            MessageBox.Show(Name);
        }
    }
}
