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

namespace UseRoutedCommand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.InitializeCommand();
        }

        //声明并定义命令
        private RoutedCommand clearCmd = new RoutedCommand("clear", typeof(MainWindow));

        //声明命令初始化的方法，包括命令赋值、命令关联等
        private void InitializeCommand()
        {
            //为命令额外添加快捷键触发方式
            /*
                KeyGesture 是一个表示键盘快捷键的类。
                Key.C 指定键盘上的 "C" 键。
                ModifierKeys.Alt 指定需要同时按下 "Alt" 键。
             */
            this.clearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));
            
            //为命令源指定命令和目标
            this.Button1.Command = this.clearCmd;
            this.Button1.CommandTarget = this.TextBox1;

            //创建命令
            // 01 创建实例
            CommandBinding cb = new CommandBinding();
            // 02 指定命令
            cb.Command = this.clearCmd;
            // 03 将CanExecute和Execute订阅相应的事件处理程序
            cb.CanExecute += new CanExecuteRoutedEventHandler(Cb_CanExecute);
            cb.Executed += new ExecutedRoutedEventHandler(Cb_Executed);

            //设置命令关联的位置
            this.StackPanel.CommandBindings.Add(cb);
        }

        //命令到达目标后要执行的事件处理器
        private void Cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.TextBox1.Clear();

            //避免向上继续执行而降低性能
            e.Handled = true;
        }

        //判断事件是否可执行的事件处理器
        private void Cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TextBox1.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }

            //避免向上继续执行而降低性能
            e.Handled = true;
        }
    }
}