using MahApps.Metro.Controls.Dialogs;
using Microsoft.Reporting.WinForms;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace AMD.Views
{
    /// <summary>
    /// Interaction logic for NewCustomerPage.xaml
    /// </summary>
    public partial class NewCustomerPage : Page
    {

        private bool CustomerName = false;

        private bool PrintButtonClicked = false;

        private bool Reciept = true;

        double Payment = 0;

        public NewCustomerPage()
        {
            InitializeComponent();

        }

        private bool _isReportViewerLoaded;

        private void _ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                Gargai grg = new Gargai();
                grg.BeginInit();


                reportDataSource1.Name = "CustomerReciept";
                reportDataSource1.Value = grg.Customer;
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this._reportViewer.LocalReport.ReportEmbeddedResource = "AMD.AMDReport.rdlc";

                grg.EndInit();

                GargaiTableAdapters.CustomerTableAdapter customer = new GargaiTableAdapters.CustomerTableAdapter();
                customer.ClearBeforeFill = true;
                customer.FillByCustomerID(grg.Customer, txtCustomerID.Text);

                ReportParameterCollection reportParameter = new ReportParameterCollection();
                reportParameter.Add(new ReportParameter("CustomerName", txtCustomerFullName.Text));
                if (PaymentType.SelectedIndex == 0)
                {
                    reportParameter.Add(new ReportParameter("PaymentType", "Cash"));
                }
                else if (PaymentType.SelectedIndex == 1)
                {
                    reportParameter.Add(new ReportParameter("PaymentType", "Transfer"));
                }
                else if (PaymentType.SelectedIndex == 2)
                {
                    reportParameter.Add(new ReportParameter("PaymentType", "Cash & Transfer"));
                }
                this._reportViewer.LocalReport.SetParameters(reportParameter);

                this._reportViewer.ShowBackButton = false;
                this._reportViewer.ShowPageNavigationControls = false;
                this._reportViewer.ShowParameterPrompts = false;
                this._reportViewer.ShowFindControls = false;
                this._reportViewer.ShowZoomControl = false;
                this._reportViewer.ShowFindControls = false;
                this._reportViewer.ShowContextMenu = false;
                this._reportViewer.ShowCredentialPrompts = false;
                this._reportViewer.ShowDocumentMapButton = false;
                this._reportViewer.ShowParameterPrompts = false;

                var setUp = this._reportViewer.GetPageSettings();
                setUp.Margins = new Margins(0, 0, 0, 0);
                this._reportViewer.SetPageSettings(setUp);
                //PageSettings pageSettings = new PageSettings();
                //pageSettings.Margins = new Margins(0,0,0,0);

                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new AMDDataContext();
            var query = from p in db.Items
                        select p;

            ItemsToPrint.ItemsSource = query.ToList();
            ItemsToPrint.DisplayMemberPath = "ItemName";
            ItemsToPrint.SelectedValuePath = "Id";

            //if (ItemsToPrint.SelectedIndex == -1)
            //{
            //    ItemsNumber.Items.Clear();
            //}
            //else
            //{
            //for (int i = 1; i <= 100; i++)
            //{
            //    ItemsNumber.Items.Add(i);
            //}
            //}

            txtCash.Visibility = Visibility.Collapsed;
            txtTransfer.Visibility = Visibility.Collapsed;
            Bank.Visibility = Visibility.Collapsed;

        }

        private void SaveItems_Click(object sender, RoutedEventArgs e)
        {

            //foreach (var row in dgvItems1.rows)
            //{

            //}

            AMDDataContext db = new AMDDataContext();
            Customer SaveItem = new Customer();

            if (PrintButtonClicked == true)
            {

                SaveItem.CustomerID = txtCustomerID.Text;
                SaveItem.CustomerName = txtCustomerFullName.Text;
                SaveItem.DateBought = DateTime.Now;
                SaveItem.PaymentType = PaymentType.Text;
                SaveItem.Cash = txtCash.Text;
                SaveItem.Transfer = txtTransfer.Text;
                SaveItem.Bank = Bank.Text;
                SaveItem.Comment = txtCustomerComment.Text;

                PrintButtonClicked = false;

                Reciept = false;

            }
            else
            {

                SaveItem.CustomerID = txtCustomerID.Text;
                SaveItem.ItemName = ItemsToPrint.Text;
                SaveItem.DateBought = DateTime.Now;
                SaveItem.Price = Convert.ToDouble(txtPiecesShopPrice.Text);
                SaveItem.Quantity = Convert.ToInt32(ItemsNumber.Text);
                SaveItem.Total = (SaveItem.Price * SaveItem.Quantity);
                SaveItem.ReducedPrice = Convert.ToDouble(txtReducedPrice.Text);

                System.Windows.Forms.MessageBox.Show("Customer successfully saved!");

                double PiecesPrice = Convert.ToDouble(txtPiecesShopPrice.Text);

                int itemsNo = Convert.ToInt32(ItemsNumber.Text);

                double TotalPayment = (PiecesPrice * itemsNo);

                Payment += TotalPayment;

                txtTotal.Text = Payment.ToString();

                txtCustomerDetailsName.Text = txtCustomerFullName.Text;

                txtPaymenttype.Text = PaymentType.Text;
            }

                if (Bank.SelectedIndex == -1)
                {
                    txtBank.Text = "No Bank";
                }
                else
                {
                    txtBank.Text = Bank.Text;
                }

                db.Customers.InsertOnSubmit(SaveItem);
                db.SubmitChanges();


            var customerid = from p in db.Customers
                                 select p;
            var FilterCustomer = customerid.Where(o => o.CustomerID.StartsWith(txtCustomerID.Text));

            dgvItems.ItemsSource = FilterCustomer;

            //ICollectionView linqview = CollectionViewSource.GetDefaultView(customerid);
            //linqview.Filter = new Predicate<object>(o =>
            //((Customer)o).CustomerID.StartsWith(txtCustomerID.Text));

               

        }


        private void ItemsToPrint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCustomerFullName.Text))
            {
                return;
            }
            else
            {
                
                if (CustomerName == false)
                {
                    return;
                }
                else
                {
                Random generator = new Random();
                string r = generator.Next(0, 999999).ToString("D6");

                txtCustomerID.Text = "gargai-" + r;
                }

                CustomerName = false;

            }

            if (ItemsNumber.SelectedValue == null)
            {
                txtPiecesReducedPrice.Text = "0";
            }
            else
            {
                //ItemsNumber.SelectedValue = -1;

                int selectedValue = Convert.ToInt32(ItemsNumber.SelectedValue.ToString());
                double priceReduced = Convert.ToDouble(txtPiecesReducedPrice.Text);

                double price = priceReduced * selectedValue;

                txtReducedPrice.Visibility = Visibility.Visible;

                txtReducedPrice.Text = price.ToString();
            }

            if (ItemsNumber.SelectedIndex == -1)
            {
                for (int i = 1; i <= 100; i++)
                {
                    ItemsNumber.Items.Add(i);
                }
                PaymentType.Items.Add("Cash");
                PaymentType.Items.Add("Transfer");
                PaymentType.Items.Add("Cash & Transfer");

                Bank.Items.Add("Access Bank");
                Bank.Items.Add("First Bank");
                Bank.Items.Add("UBA Bank");
                Bank.Items.Add("Union Bank");
                Bank.Items.Add("Zenith Bank");

            }

            else
            {
                return;
            }

        }

        private void PaymentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.PaymentType.SelectedItem.Equals("Cash"))
            {
                this.txtCash.Visibility = Visibility.Visible;
                this.txtTransfer.Visibility = Visibility.Collapsed;
                this.Bank.Visibility = Visibility.Collapsed;
            }
            else if (this.PaymentType.SelectedItem.Equals("Transfer"))
            {
                this.txtTransfer.Visibility = Visibility.Visible;
                this.txtCash.Visibility = Visibility.Collapsed;
                this.Bank.Visibility = Visibility.Visible;
            }
            else if (this.PaymentType.SelectedItem.Equals("Cash & Transfer"))
            {
                this.txtTransfer.Visibility = Visibility.Visible;
                this.txtCash.Visibility = Visibility.Visible;
                this.Bank.Visibility = Visibility.Visible;
            }
        }

        private void ItemsNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtItem.Text = ItemsToPrint.Text;
            txtTimes.Visibility = Visibility.Visible;
            double price = Convert.ToDouble(txtPiecesShopPrice.Text);
            int itemsno = Convert.ToInt32(ItemsNumber.SelectedValue.ToString());
            double totalitems = price * itemsno;
            txtItemsno.Text = ItemsNumber.SelectedValue.ToString();

            txtItemsTotal.Text = totalitems.ToString();
        }

        //private void PrintItems_ClickAsync(object sender, RoutedEventArgs e)
        //{
        //    if (e.OriginalSource is Button button)
        //    {
        //        // This dialog should be displayed only once!
        //        // So disable the button while the dialog is open.
        //        button.IsEnabled = false;
        //        await this.ShowChildWindowAsync(new Reciept(), this.MainPage).ConfigureAwait(true);
        //        button.IsEnabled = true;
        //    }

        //}

        private void PrintItems_Click(object sender, RoutedEventArgs e)
        {
            if ((PaymentType.SelectedIndex == -1) && (string.IsNullOrWhiteSpace(txtCash.Text) || string.IsNullOrWhiteSpace(txtTransfer.Text)))
            {
                System.Windows.Forms.MessageBox.Show("Payment Type, Cash or Transfer cannot be empty!");
                return;
            }

            PrintButtonClicked = true;

            ReportGrid.Visibility = Visibility.Visible;
            _reportViewer.Load += _ReportViewer_Load;

            if (Reciept == false)
            {
                return;
            }
            SaveItems_Click(this, new RoutedEventArgs());


            //_storyboard.Begin(Card);

            //PrintButtonClicked = false;
        }

        private void Reciept_OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void MainPage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ReportGrid.Visibility = Visibility.Collapsed;
        }

        private void ReportGrid_LayoutUpdated(object sender, EventArgs e)
        {
            this.InvalidateVisual();
        }

        private void txtCustomerFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerName = true;
        }

        private void RemoveCustomer_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want delete this Customer?", "Delete Customer", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

            try
            {
            AMDDataContext db = new AMDDataContext();
            var DeleteCustomer = from p in db.Customers
                                 where p.CustomerID == txtCustomerID.Text
                                 select p;

                foreach (var customer in DeleteCustomer)
                {
                     db.Customers.DeleteOnSubmit(DeleteCustomer.FirstOrDefault());
                     db.SubmitChanges();
                }

                System.Windows.Forms.MessageBox.Show("Customer deleted successfully!", "AMD Enterprise", MessageBoxButtons.OK);

                txtCustomerFullName.Text = string.Empty;

                txtCustomerID.Text = string.Empty;

            var customerid = from p in db.Customers
                             select p;
            var FilterCustomer = customerid.Where(o => o.CustomerID.StartsWith(txtCustomerID.Text));

            dgvItems.ItemsSource = null;
            }
            catch (Exception a)
            {

                System.Windows.Forms.MessageBox.Show(a.Message);
            }
            }
            else
            {
                return;
            }
        }


        //private void ItemsToPrint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var db = new AMDDataContext();
        //    var query = from p in db.Items
        //                select p;

        //    ItemsToPrint.ItemsSource = query.ToList();
        //    ItemsToPrint.DisplayMemberPath = "ItemName";
        //    ItemsToPrint.SelectedValuePath = "Id";

        //    txtPiecesShopPrice.Text = ItemsToPrint.

        //}

    }
}
