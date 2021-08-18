using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using IT481_Fitzpatrick_Unit_3.business.repositories;

namespace IT481_Fitzpatrick_Unit_3.business
{
    public class NorthwindService
    {
        private ICustomerRepository custRepo;
        private IOrderRepository orderRepo;
        private IEmployeeRepository empRepo;

        public NorthwindService(ICustomerRepository c, IEmployeeRepository e, IOrderRepository o)
        {
            this.custRepo = c;
            this.orderRepo = o;
            this.empRepo = e;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return this.custRepo.GetCustomers();
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return this.empRepo.GetEmployees();
        }
        public IEnumerable<Order> GetOrders()
        {
            return this.orderRepo.GetOrders();
        }
        public int GetCustomerCount()
        {
            return this.custRepo.GetCustomers().Count();
        }
        public IEnumerable<string> GetCustomerNames()
        {
            return (from c in this.custRepo.GetCustomers() select c.ContactName);
        }

    }
}
