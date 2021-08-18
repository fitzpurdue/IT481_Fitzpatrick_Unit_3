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
using IT481_Fitzpatrick_Unit_3.data;
using IT481_Fitzpatrick_Unit_3.business;
using System.Diagnostics;

namespace IT481_Fitzpatrick_Unit_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NorthwindService service;
        public MainWindow(NorthwindService service)
        {
            InitializeComponent();
            this.service = service;
          

        }

        private void customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cmbTable.SelectedItem;
            try
            {
                switch (item.Name)
                {
                    case "Orders":
                        dgView.ItemsSource = this.service.GetOrders();
                        dgView.Items.Refresh();
                        break;
                    case "Customers":
                        dgView.ItemsSource = this.service.GetCustomers();
                        dgView.Items.Refresh();
                        break;
                    case "Employees":
                        dgView.ItemsSource = this.service.GetEmployees();
                        dgView.Items.Refresh();
                        break;
                }

            } catch
            {
                MessageBox.Show("You do not have access to this table");
            }
        }
    }
}
