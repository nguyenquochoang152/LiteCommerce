using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;
using System.Data.SqlClient;
using System.Data;

namespace LiteCommerce.DataLayers.SqlServer
{
    public class OrderDAL : IOrderDAL
    {
        private string connectionString;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="connectionString"></param>
        public OrderDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Add(Order data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue, string country)
        {
            int count = 0;
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT  count(*)
						FROM            Customers INNER JOIN
                         Orders ON Customers.CustomerID = Orders.CustomerID INNER JOIN
                         Employees ON Orders.EmployeeID = Employees.EmployeeID INNER JOIN
                         Shippers ON Orders.ShipperID = Shippers.ShipperID
	                        where  ((@searchValue =N'') or (Customers.CompanyName like @searchValue) or (Shippers.CompanyName like @searchValue)) and ((@Country =N'') or (ShipCountry like @country))";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                cmd.Parameters.AddWithValue("@country", country);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            return count;
        }

        public string CustomerNameToID(string customerName)
        {
            throw new NotImplementedException();
        }

        public int Delete(int[] orderIDs)
        {
            throw new NotImplementedException();
        }

        public int EmployeeNametoID(string employeeName)
        {
            throw new NotImplementedException();
        }

        public OrderNameToID Get(int orderID)
        {
            OrderNameToID data = new OrderNameToID();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT  Orders.OrderID,Customers.CompanyName as CustomerCompanyName, 
                             Shippers.CompanyName AS ShipperCompanyName, Orders.OrderDate, Orders.RequiredDate, 
                             Orders.ShippedDate, Orders.Freight,
                             Orders.ShipAddress, Orders.ShipCity, Orders.ShipCountry, Employees.LastName, 
                             Employees.FirstName
						     FROM  Customers INNER JOIN
                             Orders ON Customers.CustomerID = Orders.CustomerID INNER JOIN
                             Employees ON Orders.EmployeeID = Employees.EmployeeID INNER JOIN
                             Shippers ON Orders.ShipperID = Shippers.ShipperID
						     where OrderID = @OrderID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        data = new OrderNameToID()
                        {
                            OrderID = Convert.ToInt32(reader["OrderID"]),
                            CustomerCompanyName = Convert.ToString(reader["CustomerCompanyName"]),
                            FullName = Convert.ToString(reader["FirstName"]) + " " + Convert.ToString(reader["LastName"]),
                            Freight = Convert.ToDecimal(reader["Freight"]),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(reader["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(reader["ShippedDate"]),
                            ShipAddress = Convert.ToString(reader["ShipAddress"]),
                            ShipCity = Convert.ToString(reader["ShipCity"]),
                            ShipCountry = Convert.ToString(reader["ShipCountry"]),
                            ShipperCompanyName = Convert.ToString(reader["ShipperCompanyName"])
                        };
                    }
                }

                connection.Close();
            }

            return data;
        }

        public List<OrderDetail> GetAll(int OrderID)
        {
            throw new NotImplementedException();
        }

        public List<OrderNameToID> List(int page, int pagesize, string searchValue, string shipCountry)
        {
            List<OrderNameToID> data = new List<OrderNameToID>();
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * 
                        from 
                        (
	                        SELECT row_number() over(order by Customers.CompanyName) as RowNumber, Orders.OrderID,Customers.CompanyName as CustomerCompanyName, Shippers.CompanyName AS ShipperCompanyName, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate, Orders.Freight, Orders.ShipAddress, Orders.ShipCity, Orders.ShipCountry, Employees.LastName, 
                         Employees.FirstName
						FROM            Customers INNER JOIN
                         Orders ON Customers.CustomerID = Orders.CustomerID INNER JOIN
                         Employees ON Orders.EmployeeID = Employees.EmployeeID INNER JOIN
                         Shippers ON Orders.ShipperID = Shippers.ShipperID
	                        where  ((@searchValue =N'') or (Customers.CompanyName like @searchValue) or (Shippers.CompanyName like @searchValue)) and ((@shipCountry =N'') or (ShipCountry like @shipCountry))
                        ) as t
                        where   t.RowNumber between  (@page-1)*@pageSize + 1 and @page*@pageSize
                        order by t.RowNumber";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pagesize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                cmd.Parameters.AddWithValue("@shipCountry", shipCountry);
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        data.Add(new OrderNameToID()
                        {
                            OrderID = Convert.ToInt32(reader["OrderID"]),
                            CustomerCompanyName = Convert.ToString(reader["CustomerCompanyName"]),
                            FullName = Convert.ToString(reader["FirstName"]) + " " + Convert.ToString(reader["LastName"]),
                            Freight = Convert.ToDecimal(reader["Freight"]),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(reader["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(reader["ShippedDate"]),
                            ShipAddress = Convert.ToString(reader["ShipAddress"]),
                            ShipCity = Convert.ToString(reader["ShipCity"]),
                            ShipCountry = Convert.ToString(reader["ShipCountry"]),
                            ShipperCompanyName = Convert.ToString(reader["ShipperCompanyName"])
                        });
                    }
                }

                connection.Close();
            }

            return data;
        }

        public int ShipperNametoID(string ShipperName)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order data)
        {
            throw new NotImplementedException();
        }
    }
}
