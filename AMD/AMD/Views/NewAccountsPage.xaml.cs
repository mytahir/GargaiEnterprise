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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AMD.Views
{
    /// <summary>
    /// Interaction logic for AccountsPage.xaml
    /// </summary>
    public partial class NewAccountsPage : Page
    {
        public NewAccountsPage()
        {
            InitializeComponent();
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtUserName.Text)
                || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("These Fields cannot be empty!");
            }
            var db = new AMDDataContext();
            var Users = from p in db.Users
                        where p.Username == txtUserName.Text
                        select p;
            if (Users.Count() != 0)
            {
                MessageBox.Show("User already exists!");
            }
            else
            {
                //var NewUser = new users with { FullName = txtFullName.Text, Username = txtUserName.Text, Password = txtPassword, Role = txtRole}
                var NewUser = new User();
                NewUser.FullName = txtFullName.Text;
                NewUser.Username = txtUserName.Text;
                NewUser.Password = txtPassword.Text;
                if (rdbAdminRole.IsChecked == true)
                {
                    NewUser.Role = "Admin";
                    db.Users.InsertOnSubmit(NewUser);
                    db.SubmitChanges();

                    MessageBox.Show("User successfully added as Admin!");
                }
                else
                {
                    NewUser.Role = "User";
                    db.Users.InsertOnSubmit(NewUser);
                    db.SubmitChanges();

                    MessageBox.Show("User successfully added as User!");
                }
            }
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
            }
            
        }
    }
}
