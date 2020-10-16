using AMD.Navigation;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace AMD.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private readonly Navigation.NavigationServiceEx _navigationServiceEx;

        public Dashboard()
        {

            InitializeComponent();
            this._navigationServiceEx = NavigationServiceEx.Instance;
            this._navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;
            //this.Loaded += (sender, args) =>
            //    this._navigationServiceEx.Navigate(new Uri("Views/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

       
        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            db.Visibility = Visibility.Visible;
            it.Visibility = Visibility.Hidden;
            cm.Visibility = Visibility.Hidden;
            //rc.Visibility = Visibility.Hidden;
            ac.Visibility = Visibility.Hidden;

            AMDDataContext db1 = new AMDDataContext();
            var query = from p in db1.Items
                        select p;

            dgvItems.ItemsSource = query;


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
    }

   
}
