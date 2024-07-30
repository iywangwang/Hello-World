using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM_CommandText.Controls
{
    // 编写命令源
    class ColorControlButton : Button, ICommandSource
    {
        // 继承自ICommandSource的三个属性,应为Button里以及有了
        //public ICommand Command {  get; set; }
        //public object CommandParameter { get; set; }
        //public IInputElement CommandTarget { get; set; }

        // 鼠标左键单击时触发
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (this.CommandTarget != null)
            {
                this.Command.Execute(this.CommandTarget);
            }
        }
    }
}
