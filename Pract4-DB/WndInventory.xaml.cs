using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Pract4_DB.GoldAppleTableAdapters;

namespace Pract4_DB
{
    /// <summary>
    /// Логика взаимодействия для WndInventory.xaml
    /// </summary>
    public partial class WndInventory : Window
    {
        InventoryTableAdapter adapter= new InventoryTableAdapter();
        ProductsTableAdapter productsTableAdapter = new ProductsTableAdapter();
        public WndInventory()
        {
            InitializeComponent();
            if (Settings.Role == -1)//admin
            {
                DisableEnable(true);
            }
            else
            {
                DisableEnable(false);
            }
            dgInventory.ItemsSource = adapter.GetDataByProductID();
            cbProductName.ItemsSource = productsTableAdapter.GetData();
            cbProductName.DisplayMemberPath = "ProductName";
            cbProductName.SelectedValuePath = "ID_Products";
        }

        void DisableEnable(bool status)
        {
            tbExpiration.IsEnabled = status;
            cbProductName.IsEnabled = status; 
            tbQuantity.IsEnabled = status;
            btnAdd.IsEnabled = status;
            btnDelete.IsEnabled = status;
            btnUpdate.IsEnabled = status;
            dgInventory.IsEnabled = status;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            adapter.InsertQuery(Convert.ToInt32(cbProductName.SelectedValue),Convert.ToInt32(tbQuantity.Text), String.Format("{0:yyyy.MM.dd}", tbExpiration.SelectedDate));
            dgInventory.ItemsSource = adapter.GetDataByProductID();
            HideColumnts();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgInventory.SelectedItems == null) return;

            object id = (dgInventory.SelectedItem as DataRowView).Row[0];
            adapter.DeleteQuery(Convert.ToInt32(id));
            dgInventory.ItemsSource = adapter.GetDataByProductID();
            HideColumnts();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgInventory.SelectedItem == null) return;
            int id = Convert.ToInt32((dgInventory.SelectedItem as DataRowView).Row[0]);
            adapter.UpdateQuery(Convert.ToInt32(cbProductName.SelectedValue), Convert.ToInt32(tbQuantity.Text), String.Format("{0:yyyy.MM.dd}", tbExpiration.SelectedDate),id);
            dgInventory.ItemsSource = adapter.GetDataByProductID();
            HideColumnts();

        }

        void HideColumnts()
        {
            dgInventory.Columns[0].Visibility = Visibility.Collapsed;
            dgInventory.Columns[1].Visibility = Visibility.Collapsed;

        }
        private void tbExpiration_Loaded(object sender, RoutedEventArgs e)
        {
            HideColumnts();
        }
    }
}

