using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AMD.Views
{
    /// <summary>
    /// Interaction logic for NewItemsPage.xaml
    /// </summary>
    public partial class NewItemsPage : Page
    {
         int a;
        public NewItemsPage()
        {
            InitializeComponent();
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(ItemName.Text) || string.IsNullOrWhiteSpace(BaleQuantity.Text)
                 || string.IsNullOrWhiteSpace(BaleActualPrice.Text) || string.IsNullOrWhiteSpace(BaleShopPrice.Text) 
                 || string.IsNullOrWhiteSpace(PiecesPerBale.Text) || string.IsNullOrWhiteSpace(ItemComment.Text))
            {
                MessageBox.Show("All Fields are required please!");
                return;
            }

            if (!int.TryParse(BaleQuantity.Text, out a))
            {
                MessageBox.Show("Bale Quantity must be in Number please!");
                return;
            }
            if (!int.TryParse(BaleActualPrice.Text, out a))
            {
                MessageBox.Show("Bale Actual Price must be in Number please!");
                return;
            }
            if (!int.TryParse(BaleShopPrice.Text, out a))
            {
                MessageBox.Show("Bale Shop price must be in Number please!");
                return;
            }
            if (!int.TryParse(PiecesPerBale.Text, out a))
            {
                MessageBox.Show("pieces Per Bale must be in Number please!");
                return;
            }

            var db = new AMDDataContext();

                var Items = from p in db.Items
                            where p.ItemName == ItemName.Text
                            select p;
                if(Items.Count() != 0)
            {
                MessageBox.Show("Item already exists!");
            }
            else
            {
                var NewItem = new Item();
                NewItem.ItemName = ItemName.Text;
                NewItem.DateArrived = DateTime.Now;
                NewItem.BaleQuantity = Convert.ToInt32(BaleQuantity.Text);
                NewItem.BaleActualPrice = Convert.ToInt32(BaleActualPrice.Text);
                NewItem.BaleShopPrice = Convert.ToInt32(BaleShopPrice.Text);
                NewItem.PiecesPerBale = Convert.ToInt32(PiecesPerBale.Text);
                NewItem.ItemComment = ItemComment.Text;
                NewItem.TotalPieces = (Convert.ToInt32(BaleQuantity.Text) * Convert.ToInt32(PiecesPerBale.Text));
                NewItem.PiecesActualPrice = (Convert.ToInt32(BaleActualPrice.Text) / Convert.ToInt32(PiecesPerBale.Text));
                NewItem.PiecesShopPrice = (Convert.ToInt32(BaleShopPrice.Text) / Convert.ToInt32(PiecesPerBale.Text));
                NewItem.PiecesActualPriceTotal = (Convert.ToInt32(PiecesPerBale.Text) * (Convert.ToInt32(BaleActualPrice.Text) / Convert.ToInt32(PiecesPerBale.Text)));
                NewItem.PiecesPerBaleTotal = (Convert.ToInt32(BaleQuantity.Text) * Convert.ToInt32(PiecesPerBale.Text));
                NewItem.PiecesShopPriceTotal = (Convert.ToInt32(PiecesPerBale.Text) * (Convert.ToInt32(BaleShopPrice.Text) / Convert.ToInt32(PiecesPerBale.Text)));
                NewItem.BaleActualPriceTotal = (Convert.ToInt32(BaleActualPrice.Text) * Convert.ToInt32(BaleQuantity.Text));
                NewItem.BaleShopPriceTotal = (Convert.ToInt32(BaleShopPrice.Text) * Convert.ToInt32(BaleQuantity.Text));
                
                db.Items.InsertOnSubmit(NewItem);
                db.SubmitChanges();

                MessageBox.Show("Item successfully added!");
                
            }


        }
    }
}
