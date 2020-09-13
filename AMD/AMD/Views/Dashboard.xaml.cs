using AMD.Navigation;
using System;
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

            List<items> items = new List<items>();
            items.Add(new items() { Id = 1, Items = "Roba", date = new DateTime(2019, 08, 02), Price = 5000, All = 200, Sold = 130, Remain = 70 });
            Items.ItemsSource = items;
            // Navigate to login page.
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
            rc.Visibility = Visibility.Hidden;
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

        private void btnRecords_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Records.xaml", UriKind.RelativeOrAbsolute));
        }
    }

    public class items
    {
        public int Id { get; set; }
        public string Items { get; set; }
        public DateTime date { get; set; }
        public int Price { get; set; }
        public int All { get; set; }
        public int Sold { get; set; }
        public int Remain { get; set; }

    }
}
