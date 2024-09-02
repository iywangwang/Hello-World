using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ACSTest.Resource.Converter
{
    class BorderBrackground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && (bool)value)
                return Brushes.Green;
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
