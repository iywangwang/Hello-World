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

namespace DataTemplate_NeiBuFangWen
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

        private void listViewEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person? person = (listViewEmp.SelectedItem) as Person;
            ListViewItem? lvi = this.listViewEmp.ItemContainerGenerator.ContainerFromItem(person)
                                as ListViewItem;

            //对于工作的展示，由于其是数据模板中唯一的一个TextBox，所以直接使用FindVisualChild方法即可。
            TextBox textBox = this.FindVisualChild<TextBox>(lvi);
            MessageBox.Show("Jon：" + textBox.Text);

            ContentPresenter ce = this.FindVisualChild<ContentPresenter>(lvi);
            DataTemplate dt = ce.ContentTemplate;

            TextBlock tb = dt.FindName("textBlockBthday", ce) as TextBlock;
            MessageBox.Show("Birthday：" + tb.Text);
        }

        //DependencyObject parent 是要搜索的父元素，搜索将从这个元素开始。
        //where T : DependencyObject 指定了泛型参数 T 必须是 DependencyObject 或其派生类型。
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            //获取父元素的子元素数量
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            { 
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                if (child is T)
                {
                    return (T)child;
                }

                else
                {
                    //如果当前子元素不是类型 T，方法将递归调用自身，继续在子元素的子元素中搜索。
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }
    }
}