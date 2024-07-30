using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVM_CommandText
{
    public interface IColorable
    {
        // 属性，获取或设置当前颜色
        Color CurrentColor { get; set; }

        void Clear();
        void Fill(Color color);
    }
}
