using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntelligentPlant.Models
{
    class VariableItem : INotifyPropertyChanged
    {
        public string Name { get; set; }

		private object _value;

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Value
		{
			get { return _value; }
			set { 
				_value = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("Value"));
			}
		}

		public string Unit {  get; set; }
	}
}
