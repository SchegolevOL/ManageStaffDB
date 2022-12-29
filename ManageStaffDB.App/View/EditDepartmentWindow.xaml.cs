using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ManageStaffDB.App.Model;
using ManageStaffDB.App.ViewModel;

namespace ManageStaffDB.App.View
{
    /// <summary>
    /// Interaction logic for EditDepartmentWindow.xaml
    /// </summary>
    public partial class EditDepartmentWindow : Window
    {
        public EditDepartmentWindow(Department departmentToEdit)
        {
            InitializeComponent();
            DataManageVM.SelectedDepartment = departmentToEdit;
            DataManageVM.DepartmentName = departmentToEdit.Name;
            EditDepartmrnt.Text = departmentToEdit.Name;
        }
    }
}
