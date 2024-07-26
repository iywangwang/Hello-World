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

namespace WPFSubjoinEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //为最外层的Gird实现侦听
            Staff.AddSalaryChangedHandler(this.BaseGrid, new RoutedEventHandler(this.StaffSalaryChangedHandler));
        }

        //使用按钮触发事件，并进行路由传递
        public void MainButton_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff() { Name = "XiaoZhang", Description = 6666.0};
            staff.Description = 8888.0;

            //借助Button将附加事件进行路由传递
            RoutedEventArgs args = new RoutedEventArgs(Staff.SalaryChangeEvent, staff);
            this.BaseGrid.RaiseEvent(args);
        }

        //监听者监听到事件后的事件处理程序
        private void StaffSalaryChangedHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Staff).Name.ToString() + "的工资变化了");
        }
    }
}