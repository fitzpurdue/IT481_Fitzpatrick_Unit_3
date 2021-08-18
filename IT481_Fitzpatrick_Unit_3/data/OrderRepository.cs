using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT481_Fitzpatrick_Unit_3.business.repositories;
using IT481_Fitzpatrick_Unit_3.business;
using System.Data.SqlClient;

namespace IT481_Fitzpatrick_Unit_3.data
{
    class OrderRepository : IOrderRepository
    {
        private bool disposedValue;
        private SqlConnection _conn;
        public OrderRepository(string connString)
        {
            this._conn = new SqlConnection(connString);
            this._conn.Open();
        }
        public IEnumerable<Order> GetOrders()
        {
            string sql = @"SELECT OrderID, CustomerID, EmployeeID, OrderDate,
                RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity,
                ShipRegion, ShipPostalCode, ShipCountry FROM Orders;";
            SqlCommand command = new SqlCommand(sql, this._conn);
            List<Order> results = new List<Order>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Order order = new Order();
                    order.EmployeeId = reader.GetInt32(0);
                    order.CustomerId = reader.GetStringOrDbNull(1);
                    order.EmployeeId = reader.GetInt32OrDbNull(2);
                    order.OrderDate = reader.GetDateTimeOrDbNull(3);
                    order.RequiredDate = reader.GetDateTimeOrDbNull(4);
                    order.ShippedDate = reader.GetDateTimeOrDbNull(5);
                    order.ShipVia = reader.GetInt32OrDbNull(6);
                    order.Freight = reader.GetDecimal(7);
                    order.ShipName = reader.GetStringOrDbNull(8);
                    order.ShipAddress = reader.GetStringOrDbNull(9);
                    order.ShipCity = reader.GetStringOrDbNull(10);
                    order.ShipRegion = reader.GetStringOrDbNull(11);
                    order.ShipPostalCode = reader.GetStringOrDbNull(12);
                    order.ShipCountry = reader.GetStringOrDbNull(13);
                    results.Add(order);
                }
            }
            return results;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~OrderRepository()
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
