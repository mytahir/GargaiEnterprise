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
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new AMDDataContext();
            var query = from p in db.Customers
                        select p;

            dgvCustomers.ItemsSource = query;

            var query1 = from p in db.Customers
                         where  p.DateBought.Value != null
                        select p;

            CustomersByDate.ItemsSource = query1.ToList();
            CustomersByDate.DisplayMemberPath = "DateBought";
            CustomersByDate.SelectedValuePath = "Id";
        }

        private void CustomersByDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = new AMDDataContext();
            var query = from p in db.Customers
                        where p.CustomerID != null
                        select p;

            dgvCustomers.ItemsSource = query;

            var query2 = from p in db.Customers
                        where p.CustomerID != null
                        select p;

            var Filterquery = query2.Where(o => o.DateBought.ToString().StartsWith(CustomersByDate.Text));

            CustomersByID.ItemsSource = Filterquery.Select(x => x.DateBought).Distinct().ToList();
            CustomersByID.DisplayMemberPath = "CustomerID";
            CustomersByID.SelectedValuePath = "Id";

            var customerid = from p in db.Customers
                             select p;

            var FilterCustomer = customerid.Where(o => o.DateBought.ToString().StartsWith(CustomersByDate.Text));

            dgvCustomers.ItemsSource = FilterCustomer;

        }

        private void CustomersByID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = new AMDDataContext();

            var customerid = from p in db.Customers
                             select p;
            var FilterCustomer = customerid.Where(o => o.CustomerID.ToString().StartsWith(CustomersByID.Text));

            dgvCustomers.ItemsSource = FilterCustomer;
        }
    }
}
