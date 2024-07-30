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

namespace List_HierarchicalDataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeList();
        }

        private void InitializeList()
        {
            EmployeeData emp01 = new EmployeeData() { Name = "李" };
            EmployeeData emp02 = new EmployeeData() { Name = "赖" };
            EmployeeData emp03 = new EmployeeData() { Name = "魏" };
            EmployeeData emp04 = new EmployeeData() { Name = "王" };
            EmployeeData emp05 = new EmployeeData() { Name = "刘" };

            DepartmentData dep01 = new DepartmentData()
            {
                Name = "生产",
                EmployeeDatas = new List<EmployeeData> { emp01, emp02, emp03 }
            };

            DepartmentData dep02 = new DepartmentData()
            {
                Name = "技术",
                EmployeeDatas = new List<EmployeeData> { emp04, emp05 }
            };

            CompanyData com = new CompanyData()
            {
                Name = "强盛",
                DepartmentDatas = new List<DepartmentData> { dep01, dep02 }
            };

            List<CompanyData> data = new List<CompanyData>();
            data.Add(com);

            this.treeView.ItemsSource = data;
        }
    }
}