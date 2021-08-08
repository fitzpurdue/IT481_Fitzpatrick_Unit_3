using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using IT481_Fitzpatrick_Unit_2.business.repositories;

namespace IT481_Fitzpatrick_Unit_2.business
{
    class CustomerService
    {
        private ICustomerRepository repo;
        public CustomerService(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return this.repo.GetCustomers();
        }
        public int GetCustomerCount()
        {
            return this.repo.GetCustomers().Count();
        }
        public IEnumerable<string> GetCustomerNames()
        {
            return (from c in this.repo.GetCustomers() select c.ContactName);
        }

    }
}
