using AMD.Navigation;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AMD.Views
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private readonly Navigation.NavigationServiceEx _navigationServiceEx;

        public UserPage()
        {
            InitializeComponent();
            this._navigationServiceEx = NavigationServiceEx.Instance;
            this._navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;
        }

        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        {
        }

        private void NewCustomerRB_Click(object sender, RoutedEventArgs e)
        {
            CustomerControl.Content = new NewCustomerPage();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
