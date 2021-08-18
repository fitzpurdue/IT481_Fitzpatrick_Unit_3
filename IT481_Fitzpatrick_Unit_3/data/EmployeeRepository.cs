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
    class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private bool disposedValue;
        private SqlConnection _conn;
        public EmployeeRepository(string connString)
        {
            this._conn = new SqlConnection(connString);
            this._conn.Open();
        }
        public IEnumerable<Employee> GetEmployees()
        {
            string sql = @"SELECT EmployeeID, LastName, FirstName, Title,
                TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode,
                Country, HomePhone, Salary, Extension, Photo, Notes, ReportsTo, PhotoPath
                FROM Employees";
            SqlCommand command = new SqlCommand(sql, this._conn);
            List<Employee> results = new List<Employee>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = reader.GetInt32(0);
                    emp.LastName = reader.GetStringOrDbNull(1);
                    emp.FirstName = reader.GetStringOrDbNull(2);
                    emp.Title = reader.GetStringOrDbNull(3);
                    emp.TitleOfCourtesy = reader.GetStringOrDbNull(4);
                    emp.BirthDate = reader.GetDateTime(5);
                    emp.HireDate = reader.GetDateTime(6);
                    emp.Address = reader.GetStringOrDbNull(7);
                    emp.City = reader.GetStringOrDbNull(8);
                    emp.Region = reader.GetStringOrDbNull(9);
                    emp.PostalCode = reader.GetStringOrDbNull(10);
                    emp.Country = reader.GetStringOrDbNull(11);
                    emp.HomePhone = reader.GetStringOrDbNull(12);
                    emp.Salary = reader.GetDecimal(13);
                    emp.Extension = reader.GetStringOrDbNull(14);
                    emp.Photo = (byte[])reader.GetValue(15);
                    emp.Notes = reader.GetStringOrDbNull(16);
                    emp.ReportsTo = reader.GetInt32OrDbNull(17);
                    emp.PhotoPath = reader.GetStringOrDbNull(18);
                    results.Add(emp);

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
                    this._conn.Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~EmployeeRepository()
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
