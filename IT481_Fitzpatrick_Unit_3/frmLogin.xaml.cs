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
using System.Windows.Shapes;
using IT481_Fitzpatrick_Unit_3.business;
using IT481_Fitzpatrick_Unit_3.data;
using IT481_Fitzpatrick_Unit_2;

namespace IT481_Fitzpatrick_Unit_3
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            //string connString = $"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Northwind; User Id = {username}; Password={password};"
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string connString = $"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Northwind; User Id = {username}; Password={password};";
            try
            {
                CustomerRepository custRepo = new CustomerRepository(connString);
                EmployeeRepository empRepo = new EmployeeRepository(connString);
                OrderRepository orderRepo = new OrderRepository(connString);
                NorthwindService service = new NorthwindService(custRepo, empRepo, orderRepo);
                MainWindow main = new MainWindow(service);
                main.Show();
                this.Hide();
            }
            catch (System.Data.SqlClient.SqlException _)
            {
                lblStatus.Text = "Invalid Login. Try again";
            }

        }
    }
}
