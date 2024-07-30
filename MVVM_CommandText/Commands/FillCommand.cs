using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MVVM_CommandText.Commands
{
    class FillCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        string hex;
        public string HEX { get => hex; set => hex = value; }

        public bool CanExecute(object? parameter)
        {
            if (parameter is string hex)
            {
                //这个条件表达式检查 hex 字符串是否以 "#" 开头，
                //并且长度恰好为 7 个字符。如果两个条件都满足，整个表达式的结果是 true；否则，结果是 false。
                return hex.StartsWith("#") && hex.Length == 7; ;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
#if true
            if (parameter is string p)
            {
                HEX = parameter.ToString();
            }

            IColorable colorable = parameter as IColorable;
            if (colorable != null)
            {
                // 尝试将命令参数转换为颜色
                try
                {
                    System.Windows.Media.Color color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(HEX);
                    // 调用命令目标的Fill方法
                    colorable.Fill(color);
                }
                catch (Exception ex)
                {
                    // 如果转换失败，显示错误信息
                    MessageBox.Show("不合法的HEX值", "Invalid color", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
#endif
        }
    }
}
