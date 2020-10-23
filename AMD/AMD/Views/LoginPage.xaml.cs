using AMD.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AMD.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Password.Focus();
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login_Click(this, new RoutedEventArgs());
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserName.Text) || string.IsNullOrWhiteSpace(Password.Password))
            {
                MessageBox.Show("Fields cannot be empty!");
                return;
            }
            else
            {

                Prog.Visibility = Visibility.Visible;
              
                UserName.IsEnabled = false;
                Password.IsEnabled = false;
                Login.IsEnabled = false;
                try
                {

                    Task.Run(() =>

                    {
                        Thread.Sleep(1500);

                        var db = new AMDDataContext();

                        var CheckUsers = from p in db.Users
                                         where p.Username == UserName.Text && p.Password == Password.Password
                                         select p;
                        this.Dispatcher.Invoke(() =>
                        {
                           
                                if (CheckUsers.Count() == 0)
                                {
                                    UserName.IsEnabled = true;
                                    Password.IsEnabled = true;
                                    Login.IsEnabled = true;
                                    Prog.Visibility = Visibility.Collapsed;
                                    //await this.ShowMessageAsync("","");
                                    MessageBox.Show("This User does not exist!, Please try again");

                                }

                                else
                                {
                                    var navigation = NavigationServiceEx.Instance;
                                    UserName.IsEnabled = true;
                                    Password.IsEnabled = true;
                                    Login.IsEnabled = true;
                                    Prog.Visibility = Visibility.Collapsed;

                                    //navigation.Navigate(typeof(MainPage));

                                    foreach (var user in CheckUsers)
                                    {
                                        switch (user.Role)
                                        {
                                            case "Admin":
                                                navigation.Navigate(typeof(MainPage));
                                                var nc = new NewCustomerPage();
                                                nc.txtCollector.Text = user.FullName;
                                                break;

                                            case "User":
                                                navigation.Navigate(typeof(UserPage));
                                                break;

                                            default:
                                                break;
                                        }
                                    }
                                }
                        }
                        );

                    }

                    );

                }
                catch (Exception a)
                {

                    MessageBox.Show(a.Message);
                }
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserName.Focus();
        }

    }
}
