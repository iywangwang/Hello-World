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

namespace CommandPrameter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxName.Text) || string.IsNullOrEmpty(this.textBoxAge.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string Name = this.textBoxName.Text;
            string Age = this.textBoxAge.Text;

            //用于格式化字符串，即根据指定的格式将一个或多个对象的值转换为字符串，并插入到结果字符串中的指定位置。
            if (e.Parameter.ToString() == "Teacher")
            {
                this.listBoxShow.Items.Add(string.Format("Teacher | Name : {0}; Age : {1}", Name, Age));
            }
            else
            {
                this.listBoxShow.Items.Add(string.Format("Student | Name : {0}; Age : {1}", Name, Age));
            }
        }
    }
}