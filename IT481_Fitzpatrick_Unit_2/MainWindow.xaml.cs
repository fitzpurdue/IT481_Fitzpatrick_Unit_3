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
using System.Configuration;
using IT481_Fitzpatrick_Unit_2.data;
using IT481_Fitzpatrick_Unit_2.business;

namespace IT481_Fitzpatrick_Unit_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // We pass the connString into the repo class in my setup
            string connString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            CustomerRepository repo = new CustomerRepository(connString);
            CustomerService service = new CustomerService(repo);

            lblTotalCustomers.Text = service.GetCustomerCount().ToString();
            customers.ItemsSource = service.GetCustomers();

        }

        private void customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
