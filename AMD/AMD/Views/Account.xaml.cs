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
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        private readonly Navigation.NavigationServiceEx _navigationServiceEx;

        public Account()
        {
            InitializeComponent();
            this._navigationServiceEx = NavigationServiceEx.Instance;
            this._navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;
        }

        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        { }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Account.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Items.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Customers.xaml", UriKind.RelativeOrAbsolute));
        }

        //private void btnRecords_Click(object sender, RoutedEventArgs e)
        //{
        //    this._navigationServiceEx.Navigate(new Uri("Views/Records.xaml", UriKind.RelativeOrAbsolute));
        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.Visibility = Visibility.Hidden;
            it.Visibility = Visibility.Hidden;
            cm.Visibility = Visibility.Hidden;
            //rc.Visibility = Visibility.Hidden;
            ac.Visibility = Visibility.Visible;

            AccountsRB.IsChecked = true;

            AccountsRB_Click(this, new RoutedEventArgs());
        }

        private void AccountsRB_Click(object sender, RoutedEventArgs e)
        {
            ItemsFrame.Content = new AccountsPage();

            //var db = new AMDDataContext();

            //var query = from p in db.Users
            //            select p;
            //AccountsPage accountsPage = new AccountsPage();
            //accountsPage.dgvAccounts.ItemsSource = query;
        }

        private void NewAccountsRB_Click(object sender, RoutedEventArgs e)
        {
            ItemsFrame.Content = new NewAccountsPage();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/LoginPage.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
