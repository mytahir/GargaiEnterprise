using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

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

            //CustomersByDate.ItemsSource = query1.ToList();
            //CustomersByDate.DisplayMemberPath = "DateBought";
            //CustomersByDate.SelectedValuePath = "Id";

            CustomersSelectionType.Items.Add("Daily");
            CustomersSelectionType.Items.Add("Weekly");
            CustomersSelectionType.Items.Add("Monthly");
            CustomersSelectionType.Items.Add("Yearly");
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

            //var Filterquery = query2.Where(o => o.DateBought.ToString().StartsWith(CustomersByDate.Text));

            //CustomersByID.ItemsSource = Filterquery.Select(x => x.DateBought).Distinct().ToList();
            //CustomersByID.DisplayMemberPath = "CustomerID";
            //CustomersByID.SelectedValuePath = "Id";

            var customerid = from p in db.Customers
                             select p;

            //var FilterCustomer = customerid.Where(o => o.DateBought.ToString().StartsWith(CustomersByDate.Text));

            //dgvCustomers.ItemsSource = FilterCustomer;

        }

        private void CustomersByID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = new AMDDataContext();

            var customerid = from p in db.Customers
                             select p;
            //var FilterCustomer = customerid.Where(o => o.CustomerID.ToString().StartsWith(CustomersByID.Text));

            //dgvCustomers.ItemsSource = FilterCustomer;
        }

        private void CustomersSelectionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            string filename = @"C:\Users\Abubakar Sa'id\Documents\Gargai.pdf";
            PdfPTable table = new PdfPTable(dgvCustomers.Columns.Count);

            Document doc = new Document(iTextSharp.text.PageSize.A4, 5, 5, 42, 35);

            doc.AddHeader("AMD", "GARGAI ENTERPRISES");

            doc.AddTitle("GARGAI ENTERPRISES");

            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream(filename,
                System.IO.FileMode.Create));
            doc.Open();

            for (int j = 0; j < dgvCustomers.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dgvCustomers.Columns[j].Header.ToString()));
            }
            table.HeaderRows = 1;
            IEnumerable itemsSource = dgvCustomers.ItemsSource as IEnumerable;
            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    DataGridRow row = dgvCustomers.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < dgvCustomers.Columns.Count; i++)
                        {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt !=null)
                            {
                                table.AddCell(new Phrase(txt.Text));
                            }
                        }
                    }
                }
                doc.Add(table);
                doc.Close();
            }
        }

        private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
                return null;
        }

        private void SearchID_Click(object sender, RoutedEventArgs e)
        {
            Gargai grg = new Gargai();
            GargaiTableAdapters.CustomerTableAdapter customer = new GargaiTableAdapters.CustomerTableAdapter();
            customer.ClearBeforeFill = true;
            customer.FillByCustomerID(grg.Customer, txtSearchByID.Text);

            dgvCustomers.ItemsSource = grg.Customer.AsEnumerable();

        }
    }
}
