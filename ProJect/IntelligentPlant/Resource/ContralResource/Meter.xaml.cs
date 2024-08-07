using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IntelligentPlant.Resource.ContralResource
{
    /// <summary>
    /// Meter.xaml 的交互逻辑
    /// </summary>
    public partial class Meter : UserControl
    {
        public Meter()
        {
            InitializeComponent();

            this.SizeChanged += Meter_SizeChanged;
        }

        double radious;
        double step = 220.0 / 50;
        double startAngle = 160;

        private void Meter_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.meterCanva.Children.Clear();

            radious = e.NewSize.Width / 2.0;

            for (double i = 0; i <= 50; i++)
            {
                double x1 = radious + radious * Math.Cos((startAngle + i * step) * Math.PI / 180);
                double y1 = radious + radious * Math.Sin((startAngle + i * step) * Math.PI / 180);

                double x2 = radious + (radious - 6) * Math.Cos((startAngle + i * step) * Math.PI / 180);
                double y2 = radious + (radious - 6) * Math.Sin((startAngle + i * step) * Math.PI / 180);

                if (i % 5 == 0)
                {
                    x2 = radious + (radious - 11) * Math.Cos((startAngle + i * step) * Math.PI / 180);
                    y2 = radious + (radious - 11) * Math.Sin((startAngle + i * step) * Math.PI / 180);

                    double x3 = radious - 15 + (radious - 25) * Math.Cos((startAngle + i * step) * Math.PI / 180);
                    double y3 = radious - 5 + (radious - 25) * Math.Sin((startAngle + i * step) * Math.PI / 180);

                    TextBlock textBlock = new TextBlock();
                    textBlock.Width = 30;
                    textBlock.FontSize = 10;
                    textBlock.Foreground = new SolidColorBrush(Color.FromArgb(193, 205, 205, 205));
                    textBlock.TextAlignment = TextAlignment.Center;
                    textBlock.Text = (i * 2).ToString();

                    Canvas.SetLeft(textBlock, x3);
                    Canvas.SetTop(textBlock, y3);

                    this.meterCanva.Children.Add(textBlock);
                }

                Line line = new Line()
                {
                    X1 = x1,
                    Y1 = y1,
                    X2 = x2,
                    Y2 = y2,
                    Stroke = new SolidColorBrush(Color.FromArgb(193, 205, 205, 205)),
                    StrokeThickness = 1
                };
                this.meterCanva.Children.Add(line);
            }

            double borX1 = radious + radious * 0.6 * Math.Cos(startAngle * Math.PI / 180);
            double borY1 = radious + radious * 0.6 * Math.Sin(startAngle * Math.PI / 180);

            double borX2 = radious + radious * 0.6 * Math.Cos((startAngle + 220) * Math.PI / 180);
            double borY2 = radious + radious * 0.6 * Math.Sin((startAngle + 220) * Math.PI / 180);

            string data = $"M {borX1},{borY1} A {radious * 0.6},{radious * 0.6} 0 1 1 {borX2},{borY2}";
            this.borderPath.Data = Geometry.Parse(data);
            UpData();
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(Meter), new PropertyMetadata(0.0, new PropertyChangedCallback(OnValueChanged)));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Meter).UpData();
        }

        private void UpData()
        {
            double x1 = radious + radious * 0.6 * Math.Cos(startAngle * Math.PI / 180);
            double y1 = radious + radious * 0.6 * Math.Sin(startAngle * Math.PI / 180);

            double current = this.Value * 220 / 100;
            double x2 = radious + radious * 0.6 * Math.Cos((current + this.startAngle) * Math.PI / 180);
            double y2 = radious + radious * 0.6 * Math.Sin((current + this.startAngle) * Math.PI / 180);

            int flag = this.Value > 82 ? 1 : 0;
            string dataPath = $"M {x1},{y1} A {radious * 0.6},{radious * 0.6} 0 {flag} 1 {x2},{y2}";
            this.valuePath.Data = Geometry.Parse(dataPath);
        }

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Unit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(Meter), new PropertyMetadata(""));
    }
}
