using ACS.SPiiPlusNET;
using ACSTest.Commands;
using ACSTest.MainViewModel;
using ACSTest.Models;
using Microsoft.Win32;
using System.ComponentModel;
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

namespace ACSTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new ViewModel();
        }
        private void RadButton_Checked(object sender, RoutedEventArgs e)
        {
            this.ConncetBtn.IsEnabled = true;
            this.IpTextBox.IsEnabled = true;
            this.PortTextBox.IsEnabled = true;

            if (NtherentRadBtn.IsChecked == true)
            {
                this.IpTextBox.IsEnabled = true;
                this.PortTextBox.IsEnabled = true;
            }
            else
            {
                this.IpTextBox.IsEnabled = false;
                this.PortTextBox.IsEnabled = false;
            }
        }

        private void ConncetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.ConncetBtn.Content.ToString() == "连接到控制器")
            {
                try
                {
                    if (this.NtherentRadBtn.IsChecked == true)
                        ModelACS.apiInstance.OpenCommEthernetTCP(Etherent.EtherentInstance.Ip, int.Parse(Etherent.EtherentInstance.Prot));
                    if (this.SimulatorRadBtn.IsChecked == true)
                        ModelACS.apiInstance.OpenCommSimulator();
                }
                catch (ACSException ex)
                {
                    MessageBox.Show("连接到控制器失败");
                    return;
                }

                this.SimulatorRadBtn.IsEnabled = false;
                this.NtherentRadBtn.IsEnabled = false;
                this.IpTextBox.IsEnabled = false;
                this.PortTextBox.IsEnabled = false;

                ViewModel.IsConnected = true;
                this.ConncetBtn.Content = "关闭连接";

                this.AxisConnectBtn.IsEnabled = true;
                this.KillAllAxisBtn.IsEnabled = true;

                return;
            }
            if (this.ConncetBtn.Content.ToString() == "关闭连接")
            {
                ModelACS.apiInstance.CloseComm();

                this.NtherentRadBtn.IsEnabled = true;
                this.SimulatorRadBtn.IsEnabled = true;

                if (this.NtherentRadBtn.IsChecked == true)
                {
                    this.IpTextBox.IsEnabled = true;
                    this.PortTextBox.IsEnabled = true;
                }

                ViewModel.IsConnected = false;
                this.ConncetBtn.Content = "连接到控制器";
                
                this.AxisConnectBtn.IsEnabled = false;
                this.KillAllAxisBtn.IsEnabled= false;

                return ;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\CSharp_Study\Array\ProJect\ACS\ACSTest";
            ofd.Title = "选择文件";
            //ofd.Filter = "ANSI文件|*.ANSI";
            ofd.ShowDialog();

            this.FilePlaceText.Text = ofd.FileName;            
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            this.FilePlaceText.Clear();
        }

        private void IntoControl_Click(object sender, RoutedEventArgs e)
        {
            //ModelACS.apiInstance.LoadDataToController((int)GeneralDefinition.ACSC_FILE,
            //    "MyArrayInFile", Api.ACSC_NONE, Api.ACSC_NONE, Api.ACSC_NONE, Api.ACSC_NONE,
            //    this.FilePlaceText.Text, (int)GeneralDefinition.ACSC_INT_BINARY, false);
        }
    }
}