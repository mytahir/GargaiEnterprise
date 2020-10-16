using AMD.Navigation;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace AMD.Views
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        private readonly Navigation.NavigationServiceEx _navigationServiceEx;
        public Customers()
        {
            InitializeComponent();
            this._navigationServiceEx = NavigationServiceEx.Instance;
            this._navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;
            NewCustomers.Content = new CustomersPage();
        }

        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.Visibility = Visibility.Hidden;
            it.Visibility = Visibility.Hidden;
            cm.Visibility = Visibility.Visible;
            //rc.Visibility = Visibility.Hidden;
            ac.Visibility = Visibility.Hidden;
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

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Account.xaml", UriKind.RelativeOrAbsolute));
        }

        private void NewCustomerRB_Click(object sender, RoutedEventArgs e)
        {
            NewCustomers.Content = new NewCustomerPage();
        }

        private void CustomerRB_Click(object sender, RoutedEventArgs e)
        {
            NewCustomers.Content = new CustomersPage();
        }
    }
}
