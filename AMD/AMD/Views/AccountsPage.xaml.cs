﻿using GalaSoft.MvvmLight.Helpers;
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
    public partial class AccountsPage : Page
    {
        public AccountsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            var db = new AMDDataContext();
            var query = from p in db.Users
                        select p;

            dgvAccounts.ItemsSource = query;


        }
    }
}
