using AMD.Navigation;
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
            if(e.Key == Key.Enter)
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
            if((UserName.Text == "mustapha") && (Password.Password == "yusuf"))
            {
            var navigation = NavigationServiceEx.Instance;
            navigation.Navigate(typeof(MainPage));
            // or
            //navigation.Navigate(new Uri("Views/MainPage.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!, Please try again");
            }
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserName.Focus();
        }
    }
}
