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
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public EditUserWindow(User userToEdit)
        {
            InitializeComponent();
            DataManageVM.SelectedUser = userToEdit;
            DataManageVM.UserName = userToEdit.Name;
            DataManageVM.UserSurName = userToEdit.SurName;
            DataManageVM.UserPhone = userToEdit.Phone;
            DataManageVM.UserPosition = userToEdit.Position;
            
            EditName.Text = userToEdit.Name;
            EditSurName.Text = userToEdit.SurName;
            EditPhone.Text = userToEdit.Phone;
            EditPosition.Text = userToEdit.UserPosition.Name;
            

        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
