using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for EditPositionWindow.xaml
    /// </summary>
    public partial class EditPositionWindow : Window
    {
        public EditPositionWindow(Position positionToEdit)
        {
            InitializeComponent();
            DataManageVM.SelectedPosition = positionToEdit;
            DataManageVM.PositionName = positionToEdit.Name;
            DataManageVM.PositionMaxNumber = positionToEdit.MaxNumber;
            DataManageVM.PositionSalary = positionToEdit.Salery;
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
