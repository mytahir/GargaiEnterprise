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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly Navigation.NavigationServiceEx _navigationServiceEx;

        public MainPage()
        {
            InitializeComponent();

            this._navigationServiceEx = NavigationServiceEx.Instance;
            this._navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;

            // Navigate to login page.
            this.Loaded += (sender, args) =>
                this._navigationServiceEx.Navigate(new Uri("Views/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        {
        }

    //    private void Page_Loaded(object sender, RoutedEventArgs e)
    //    {
    //        db.Visibility = Visibility.Visible;
    //        it.Visibility = Visibility.Hidden;
    //        cm.Visibility = Visibility.Hidden;
    //        rc.Visibility = Visibility.Hidden;
    //    }

    //    private void btnDashboard_Click(object sender, RoutedEventArgs e)
    //    {
    //        db.Visibility = Visibility.Visible;
    //        it.Visibility = Visibility.Hidden;
    //        cm.Visibility = Visibility.Hidden;
    //        rc.Visibility = Visibility.Hidden; 
    //        this._navigationServiceEx.Navigate(new Uri("Views/Dashboard.xaml", UriKind.RelativeOrAbsolute));
    //    }

    //    private void btnItems_Click(object sender, RoutedEventArgs e)
    //    {
    //        db.Visibility = Visibility.Hidden;
    //        cm.Visibility = Visibility.Hidden;
    //        rc.Visibility = Visibility.Hidden;
    //        it.Visibility = Visibility.Visible;
    //    }

    //    private void btnCustomers_Click(object sender, RoutedEventArgs e)
    //    {
    //        it.Visibility = Visibility.Hidden;
    //        db.Visibility = Visibility.Hidden;
    //        rc.Visibility = Visibility.Hidden;
    //        cm.Visibility = Visibility.Visible;
    //    }

    //    private void btnRecords_Click(object sender, RoutedEventArgs e)
    //    {
    //        it.Visibility = Visibility.Hidden;
    //        cm.Visibility = Visibility.Hidden;
    //        db.Visibility = Visibility.Hidden;
    //        rc.Visibility = Visibility.Visible;
    //    }
    }
}
