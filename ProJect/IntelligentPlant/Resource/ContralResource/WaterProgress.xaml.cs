using System.Windows;
using System.Windows.Controls;

namespace IntelligentPlant.Resource.ContralResource
{
    /// <summary>
    /// WaterProgress.xaml 的交互逻辑
    /// </summary>
    public partial class WaterProgress : UserControl
    {
        public WaterProgress()
        {
            InitializeComponent();
        }

        public double Volume
        {
            get { return (double)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Volume.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.Register("Volume", typeof(double), typeof(WaterProgress), new PropertyMetadata(0.0, new PropertyChangedCallback(OnvolumeChanged)));

        private static void OnvolumeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            double value = (double)e.NewValue;
            (d as WaterProgress).volume.Y = 160 - value * 170 / 100;
        }
    }
}
