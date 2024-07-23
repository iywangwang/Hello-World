using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListBox_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Color> l = new List<Color>();

            l.Add(new Color() { color = "#DB7093", Colorname = "苍白的紫罗兰红色" });
            l.Add(new Color() { color = "#FF69B4", Colorname = "热情的粉红" });
            l.Add(new Color() { color = "#FF1493", Colorname = "深粉色" });
            l.Add(new Color() { color = "#C71585", Colorname = "适中的紫罗兰红色" });
            l.Add(new Color() { color = "#DA70D6", Colorname = "兰花的紫色" });

            myGrid.ItemsSource = l;
        }

        class Color
        {
            public string color { get; set; }
            public string Colorname { get; set; }
        }
    }
}