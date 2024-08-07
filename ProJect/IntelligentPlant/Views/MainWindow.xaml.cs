using IntelligentPlant.ViewModels;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IntelligentPlant.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewsModels();

            this.SizeChanged += DeciceBaxkground_SizeChanged;
        }

        //画刻度
        private void DeciceBaxkground_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.deviceImage_Canvas.Children.Clear();

            double radius = 143.0;

            for (int i = 0; i < 360; i += 2)
            {
                //外层刻度坐标
                double x1 = radius + radius * Math.Cos(i * Math.PI / 180);
                double y1 = radius + radius * Math.Sin(i * Math.PI / 180);

                //内层刻度坐标
                double x2 = radius + (radius - 9) * Math.Cos(i * Math.PI / 180);
                double y2 = radius + (radius - 9) * Math.Sin(i * Math.PI / 180);

                if (i % 4 == 0)
                {
                    x2 = radius + (radius - 5) * Math.Cos(i * Math.PI / 180);
                    y2 = radius + (radius - 5) * Math.Sin(i * Math.PI / 180);
                }

                Line line = new Line()
                {
                    X1 = x1,
                    Y1 = y1,
                    X2 = x2,
                    Y2 = y2,
                    Stroke = Brushes.White,
                    StrokeThickness = 0.4
                };

                this.deviceImage_Canvas.Children.Add(line);
            }
        }
    }
}