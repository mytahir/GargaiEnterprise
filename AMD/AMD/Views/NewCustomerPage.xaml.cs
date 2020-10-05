using AMD.GargaiTableAdapters;
using MahApps.Metro.SimpleChildWindow;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AMD.Views
{
    /// <summary>
    /// Interaction logic for NewCustomerPage.xaml
    /// </summary>
    public partial class NewCustomerPage : Page
    {

        double Payment = 0;

        public NewCustomerPage()
        {
            InitializeComponent();

            //Storyboard sb = new Storyboard();
            //sb.FillBehavior = FillBehavior.HoldEnd;

            //var opacityAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(200)));
            //Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(nameof(Card.Opacity)));

            //sb.Children.Add(opacityAnimation);

            //var translateAnimation = new DoubleAnimation(50, 0, new Duration(TimeSpan.FromMilliseconds(300)));
            //Storyboard.SetTargetProperty(translateAnimation, new PropertyPath($"{nameof(Card.RenderTransform)}.{nameof(TranslateTransform.X)}"));

            //sb.Children.Add(translateAnimation);

            //_storyboard = sb;

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

                var SaveItem = new Customer();
                SaveItem.CustomerName = txtCustomerFullName.Text;
                SaveItem.CustomerID = txtCustomerID.Text;
                SaveItem.DateBought = DateTime.Now;
                SaveItem.ItemName = ItemsToPrint.Text;
                SaveItem.Price = Convert.ToDouble(txtPiecesShopPrice.Text);
                SaveItem.Quantity = Convert.ToInt32(ItemsNumber.Text);
                SaveItem.PaymentType = PaymentType.Text;
                SaveItem.Cash = txtCash.Text;
                SaveItem.Transfer = txtTransfer.Text;
                SaveItem.Bank = Bank.Text;
                SaveItem.Total = (SaveItem.Price * SaveItem.Quantity);
                SaveItem.ReducedPrice = Convert.ToDouble(txtReducedPrice.Text);
                SaveItem.Comment = txtCustomerComment.Text;

                db.Customers.InsertOnSubmit(SaveItem);
                db.SubmitChanges();
                MessageBox.Show("Customer successfully saved!");

                var customerid = from p in db.Customers
                                 select p;

                dgvItems.ItemsSource = customerid;

                txtCustomerDetailsName.Text = txtCustomerFullName.Text;


                txtPaymenttype.Text = PaymentType.Text;

                if (Bank.SelectedIndex == -1)
                {
                    txtBank.Text = "No Bank";
                }
                else
                {
                    txtBank.Text = Bank.Text;
                }

                double PiecesPrice = Convert.ToDouble(txtPiecesShopPrice.Text);

                int itemsNo = Convert.ToInt32(ItemsNumber.Text);

                double TotalPayment = (PiecesPrice * itemsNo);

                Payment += TotalPayment;

                txtTotal.Text = Payment.ToString();
                //ItemsToPrint.ItemsSource = query.ToList();
                //ItemsToPrint.DisplayMemberPath = "ItemName";
                //ItemsToPrint.SelectedValuePath = "Id";
        }

        private void ItemsToPrint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //ItemsNumber.Items.Clear();

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

        private void txtFullName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCustomerFullName.Text))
            {
                txtCustomerID.Text = string.Empty;
                PaymentType.Items.Clear();
            }
            else
            {
                Random generator = new Random();
                string r = generator.Next(0, 999999).ToString("D6");

                txtCustomerID.Text = "gargai-" + r;

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

        private void txtPiecesReducedPrice_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ItemsNumber.SelectedValue == null)
            {
                txtPiecesReducedPrice.Text = "0";
            }
            else
            {
            int selectedValue = Convert.ToInt32(ItemsNumber.SelectedValue.ToString());
            double priceReduced = Convert.ToDouble(txtPiecesReducedPrice.Text);

            double price = priceReduced * selectedValue;

            txtReducedPrice.Visibility = Visibility.Visible;

            txtReducedPrice.Text = price.ToString();
            }

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

            ReportGrid.Visibility = Visibility.Visible;
            _reportViewer.Load += _ReportViewer_Load;

            //_storyboard.Begin(Card);
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
