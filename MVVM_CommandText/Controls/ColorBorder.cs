using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MVVM_CommandText.Controls
{
    class ColorBorder : Border, IColorable
    {
        public static readonly DependencyProperty CurrentColorProperty = 
            DependencyProperty.Register("CurrentColor", typeof(System.Windows.Media.Color), typeof(ColorBorder),
                new PropertyMetadata(Colors.Transparent));

        public System.Windows.Media.Color CurrentColor
        {
            get { return (System.Windows.Media.Color)GetValue(CurrentColorProperty); }
            set { SetValue(CurrentColorProperty, value); }
        }

        // 清除颜色-设置为透明
        public void Clear()
        {
            // 设置当前颜色和背景色为透明
            this.CurrentColor = Colors.Transparent;
            this.Background = Brushes.Transparent;
        }

        public void Fill(System.Windows.Media.Color color)
        {
            // 设置当前颜色和背景色
            this.CurrentColor = color;
            this.Background = new SolidColorBrush(color);
        }
    }
}
