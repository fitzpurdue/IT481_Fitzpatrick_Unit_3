#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IT481_Fitzpatrick_Unit_3.business;
using IT481_Fitzpatrick_Unit_3.business.repositories;
using System.Data.SqlClient;

namespace IT481_Fitzpatrick_Unit_3.data
{

    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private bool disposedValue;
        private SqlConnection _conn;
        public CustomerRepository(string connString)
        {
            this._conn = new SqlConnection(connString);
            this._conn.Open();
        }

        public void CreateCustomer(Customer customer)
        {
            string sql = @$"
                INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone Fax)
                    VALUES ({customer.CustomerID}, {customer.CompanyName}, {customer.ContactName}, {customer.ContactTitle}, {customer.Address}, {customer.City}, 
                    {customer.Region}, {customer.PostalCode}, {customer.Country}, {customer.Phone}, {customer.Fax})
                    RETURNING id;";
            SqlCommand command = new SqlCommand(sql);
            command.ExecuteNonQuery();
            
        }

        public void DeleteCustomer(Customer customer)
        {
            string sql = "DELETE FROM Customers WHERE CustomerID = @ID;";
            SqlCommand command = new SqlCommand(sql, this._conn);
            command.Parameters.Add("@ID", System.Data.SqlDbType.NChar);
            command.Parameters["@ID"].Value = customer.CustomerID;
            command.ExecuteNonQuery();

           
        }

        public Customer? GetCustomerById(string customerId)
        {
            string sql = @"SELECT 
                CustomerID, CompanyName, ContactName, ContactTitle, Address, City,
                Region, PostalCode, Country, Phone, Fax FROM Customers WHERE CustomerID = @ID;";
            SqlCommand command = new SqlCommand(sql, this._conn);
            command.Parameters.Add("@ID", System.Data.SqlDbType.NChar);
            command.Parameters["@ID"].Value = customerId;
            Customer? cust = null;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    cust = GetCustomerFromReader(reader);
                }
            }
            return cust;
            
        }
       
        private Customer GetCustomerFromReader(SqlDataReader reader)
        {
           
            Customer cust = new Customer();
            cust.CustomerID = reader.GetStringOrDbNull(0);
            cust.CompanyName = reader.GetStringOrDbNull(1);
            cust.ContactName = reader.GetStringOrDbNull(2);
            cust.ContactTitle = reader.GetStringOrDbNull(3);
            cust.Address = reader.GetStringOrDbNull(4);
            cust.City = reader.GetStringOrDbNull(5);
            cust.Region = reader.GetStringOrDbNull(6);
            cust.PostalCode = reader.GetStringOrDbNull(7);
            cust.Country = reader.GetStringOrDbNull(8);
            cust.Phone = reader.GetStringOrDbNull(9);
            cust.Fax = reader.GetStringOrDbNull(10);
            return cust;
        }
   
        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> results = new List<Customer>();
            string sql = @"SELECT 
                CustomerID, CompanyName, ContactName, ContactTitle, Address, City,
                Region, PostalCode, Country, Phone, Fax FROM Customers;";
            SqlCommand command = new SqlCommand(sql, this._conn);
           
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(this.GetCustomerFromReader(reader));
                }
               
            }
            return results;
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    this._conn.Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CustomerRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
