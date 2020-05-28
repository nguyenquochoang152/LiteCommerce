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
    public class EmployeeDAL : IEmployeeDAL
    {
        private string connectionString;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="connectionString"></param>
        public EmployeeDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add(Employee data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            int count = 0;
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                ///1.thiet lap ket noi
                ///2.tạo câu lệnh
                ///3.thực thi câu lệnh
                ///4.trả về kq
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select count(*) from Employees where @searchValue =N''or FirstName like @searchValue";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                count = Convert.ToInt32(cmd.ExecuteScalar());

                connection.Close();
            }



            return count;
        }

        public int Detele(int[] employeeIDs)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        public List<Employee> List(int page, int pageSize, string searchValue)
        {
            List<Employee> data = new List<Employee>();
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //tạo lệnh thực thi truy vấn dữ liệu
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT *
                                    FROM
                                    (
	                                    SELECT ROW_NUMBER() OVER(ORDER BY FirstName) as RowNumber,Employees.*
	                                    from Employees
	                                    where (@searchValue = N'') or (FirstName like @searchValue)

                                    ) as t
                                    where t.RowNumber between (@page -1)*@pageSize +1 and (@page*@pageSize) order by t.RowNumber";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        data.Add(new Employee()
                        {
                            EmployeeID = Convert.ToInt32(dbReader["EmployeeID"]),
                            LastName = Convert.ToString(dbReader["LastName"]),
                            FirstName = Convert.ToString(dbReader["FirstName"]),
                            Title = Convert.ToString(dbReader["Title"]),
                            BirthDate = Convert.ToString(dbReader["BirthDate"]),
                            HireDate = Convert.ToString(dbReader["HireDate"]),
                            Email = Convert.ToString(dbReader["Email"]),
                            Address = Convert.ToString(dbReader["Address"]),
                            City = Convert.ToString(dbReader["City"]),
                            Country = Convert.ToString(dbReader["Country"]),
                            HomePhone = Convert.ToString(dbReader["HomePhone"]),
                            Notes = Convert.ToString(dbReader["Notes"]),
                            PhotoPath = Convert.ToString(dbReader["PhotoPath"]),
                            Password = Convert.ToString(dbReader["Password"]),


                        });
                    }

                }
                connection.Close();
            }
            return data;
        }

        public bool Update(Employee date)
        {
            throw new NotImplementedException();
        }
    }
}
