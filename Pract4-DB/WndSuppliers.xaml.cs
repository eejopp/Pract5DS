using Pract4_DB.GoldAppleTableAdapters;
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

namespace Pract4_DB
{
    /// <summary>
    /// Логика взаимодействия для WndSuppliers.xaml
    /// </summary>
    public partial class WndSuppliers : Window
    {
        SuppliersTableAdapter adapter = new SuppliersTableAdapter();
        ProductsTableAdapter productsTableAdapter = new ProductsTableAdapter();
        public WndSuppliers()
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
            dgSuppliers.ItemsSource = adapter.GetDataByID_Suppliers();
            cbProductName.ItemsSource = productsTableAdapter.GetData();
            cbProductName.DisplayMemberPath = "ProductName";
            cbProductName.SelectedValuePath = "ID_Products";
        }

        void DisableEnable(bool status)
        {
            tbCompanyName.IsEnabled = status;
            tbEmail.IsEnabled = status; 
            tbPhoneNumber.IsEnabled = status;
            cbProductName.IsEnabled = status;
            tbSuppliersName.IsEnabled = status; 
            btnAdd.IsEnabled = status;
            btnDelete.IsEnabled = status;
            btnUpdate.IsEnabled = status;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (cbProductName.SelectedValue == null) return;
            adapter.InsertQuery(tbCompanyName.Text,tbSuppliersName.Text,tbPhoneNumber.Text,tbEmail.Text, Convert.ToInt32(cbProductName.SelectedValue));
            dgSuppliers.ItemsSource = adapter.GetDataByID_Suppliers();
            HideColumns();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgSuppliers.SelectedItems == null) return;
            object id = (dgSuppliers.SelectedItem as DataRowView).Row[0];
            adapter.DeleteQuery(Convert.ToInt32(id));
            dgSuppliers.ItemsSource=adapter.GetDataByID_Suppliers();
            HideColumns();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgSuppliers.SelectedItem == null) return;
            var selected = dgSuppliers.SelectedItem as DataRowView;
            if (selected == null) return;
            int id = Convert.ToInt32((selected).Row[0]);
            adapter.UpdateQuery(tbCompanyName.Text, tbSuppliersName.Text, tbPhoneNumber.Text, tbEmail.Text, Convert.ToInt32(cbProductName.SelectedValue), id);
            dgSuppliers.ItemsSource = adapter.GetDataByID_Suppliers();
            HideColumns();
        }

        void HideColumns()
        {
            dgSuppliers.Columns[0].Visibility = Visibility.Collapsed;
            dgSuppliers.Columns[5].Visibility = Visibility.Collapsed;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HideColumns();
        }
    }
}

