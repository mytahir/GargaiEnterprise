using AMD.GargaiTableAdapters;
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

        public NewCustomerPage()
        {
            InitializeComponent();
            //_reportViewer.Load += _ReportViewer_Load;

        }

        //private bool _isReportViewerLoaded;

        private void _ReportViewer_Load(object sender, EventArgs e)
        {
            //if (!_isReportViewerLoaded)
            //{
            //    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            //    Gargai grg = new Gargai();
            //    grg.BeginInit();

            //    reportDataSource1.Name = "AMDEnterprise";
            //    reportDataSource1.Value = grg.Items;
            //    this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            //    this._reportViewer.LocalReport.ReportEmbeddedResource = "AMD.AMDReport.rdlc";

            //    grg.EndInit();

            //    GargaiTableAdapters.ItemsTableAdapter items = new GargaiTableAdapters.ItemsTableAdapter();
            //    items.ClearBeforeFill = true;
            //    items.Fill(grg.Items);

            //    _reportViewer.RefreshReport();
            //    _isReportViewerLoaded = true;
            //}
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



        }

        private void SaveItems_Click(object sender, RoutedEventArgs e)
        {
            //foreach (var row in dgvItems1.rows)
            //{

            //}
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
