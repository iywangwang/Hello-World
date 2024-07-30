using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_HierarchicalDataTemplate
{
    //公司
    class CompanyData
    {
        public string Name { get; set; }
        public List<DepartmentData> DepartmentDatas { get; set; }
    }

    //部门
    class DepartmentData
    {
        public string Name { get; set; }
        public List<EmployeeData> EmployeeDatas { get; set; }
    }

    //员工
    class EmployeeData
    {
        public string Name { get; set; }
    }
}
