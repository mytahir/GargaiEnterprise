﻿using AMD.Navigation;
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
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Page
    {
        private readonly Navigation.NavigationServiceEx _navigationServiceEx;
        public Items()
        {
            InitializeComponent();
            this._navigationServiceEx = NavigationServiceEx.Instance;
            this._navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;
            NewItems.Content = new ItemsPage();

        }

        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.Visibility = Visibility.Hidden;
            it.Visibility = Visibility.Visible;
            cm.Visibility = Visibility.Hidden;
            //rc.Visibility = Visibility.Hidden;
            ac.Visibility = Visibility.Hidden;
        }

        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Items.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Customers.xaml", UriKind.RelativeOrAbsolute));
        }

        //private void btnRecords_Click(object sender, RoutedEventArgs e)
        //{
        //    this._navigationServiceEx.Navigate(new Uri("Views/Records.xaml", UriKind.RelativeOrAbsolute));
        //}

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewItemsRB_Click(object sender, RoutedEventArgs e)
        {
            NewItems.Content = new NewItemsPage();
        }

        private void ItemsRB_Click(object sender, RoutedEventArgs e)
        {
            NewItems.Content = new ItemsPage();
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            this._navigationServiceEx.Navigate(new Uri("Views/Account.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
