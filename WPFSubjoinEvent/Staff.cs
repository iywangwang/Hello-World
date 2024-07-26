using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFSubjoinEvent
{
    public class Staff      //职工
    {
        public string Name { get; set; }
        public double Description { get; set; }     //薪水

        public static readonly RoutedEvent SalaryChangeEvent = EventManager.RegisterRoutedEvent
            ("SalaryChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Staff));
        
        public static void AddSalaryChangedHandler(DependencyObject d, RoutedEventHandler h)
        {
            UIElement uIE = d as UIElement;
            if (uIE != null)
            {
                uIE.AddHandler(Staff.SalaryChangeEvent, h);
            }
        }

        public static void RemoveSalaryChangedHandler(DependencyObject d, RoutedEventHandler h)
        {
            UIElement uIE = d as UIElement;
            if (uIE != null)
            {
                uIE.RemoveHandler(Staff.SalaryChangeEvent, h);
            }
        }
        
        }
        
}
