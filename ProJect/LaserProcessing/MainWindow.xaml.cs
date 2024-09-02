using Microsoft.Win32;
using System.IO;
using System;
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

namespace LaserProcessing
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

        private void CommandBinding_NewFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_NewFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"C:\CSharp_Study\Array\ProJect\LaserProcessing";
            fd.Title = "新建文件";
            fd.Filter = "所有文件|*.*";
            fd.ShowDialog();
        }

        private void CommandBinding_OpenFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_OpenFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"C:\CSharp_Study\Array\ProJect\LaserProcessing";
            fd.Title = "选择文件";
            fd.Filter = "XAML文件|*.xaml;*.xomal";
            fd.ShowDialog();

        }

        private void CommandBinding_SeveFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_SeveFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.InitialDirectory = @"C:\CSharp_Study\Array\ProJect\LaserProcessing";
            fd.Title = "保存文件";
            fd.Filter = "所有文件|*.*";

            if (fd.ShowDialog() == true)
            {
                string fdName = fd.FileName;
                MessageBox.Show($"保存成功:{fdName}");
            }
            else
            {
                MessageBox.Show("取消保存/失败");
            }
        }
    }
}