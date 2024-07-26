using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFDIYEvevt
{
    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) 
            : base(routedEvent, source) { }

        //用于存储路由事件触发时的时间
        public DateTime ClickTime { get; set; }
    }
}
