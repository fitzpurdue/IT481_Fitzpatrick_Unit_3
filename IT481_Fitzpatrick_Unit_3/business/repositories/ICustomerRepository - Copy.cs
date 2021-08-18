using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_Fitzpatrick_Unit_3.business.repositories
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(string customerId);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

    }
}
