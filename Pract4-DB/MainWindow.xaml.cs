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
using Pract4_DB.CredentialsDBTableAdapters;

namespace Pract4_DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CredentialsDBTableAdapters.credentialsTableAdapter adapter=new credentialsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var allLogin = adapter.GetData().Rows;
            bool login=false;
            int i;
            for (i = 0;i<allLogin.Count;i++)
            {
                if (allLogin[i][1].ToString()==tbLogin.Text && allLogin[i][2].ToString()==tbPassword.Password) 
                {
                    login = true;
                    break;
                }
            }
            if (login)
            {
                int roleId = (int)allLogin[i][3];
                Settings.Role = roleId;
                switch (roleId)
                {
                    case 0://admin
                        WndAdmin wndAdmin=new WndAdmin();
                        wndAdmin.Show();
                        break;
                    case 1://manager
                        WndManager wndManager=new WndManager();
                        wndManager.Show();
                        break;

                }

            }
            else
            {
                MessageBox.Show("Login is failed");
            }
        }
    }
}
