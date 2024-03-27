﻿using System;
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
using System.Windows.Shapes;

namespace Pract4_DB
{
    /// <summary>
    /// Логика взаимодействия для WndAdmin.xaml
    /// </summary>
    public partial class WndAdmin : Window
    {
        public WndAdmin()
        {
            InitializeComponent();
        }

        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            WndSuppliers wndSuppliers = new WndSuppliers();
            wndSuppliers.Show();
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            WndInventory wndInventory = new WndInventory();
            wndInventory.Show();
        }

        private void btnDiscounts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
