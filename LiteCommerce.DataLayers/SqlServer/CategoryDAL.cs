using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SqlServer
{
    public class CategoryDAL : ICategoryDAL
    {

        private string connectionString;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="connectionString"></param>
        public CategoryDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add(Category data)
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
                cmd.CommandText = @"select count(*) from Categories where @searchValue =N''or CategoryName like @searchValue";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                count = Convert.ToInt32(cmd.ExecuteScalar());

                connection.Close();
            }
            return count;
        }

        public int Detele(int[] categoryIDs)
        {
            throw new NotImplementedException();
        }

        public Category Get(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public List<Category> List(int page, int pageSize, string searchValue)
        {
            List<Category> data = new List<Category>();
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
	                                    SELECT ROW_NUMBER() OVER(ORDER BY CategoryID) as RowNumber,Categories.*
	                                    from Categories
	                                    where (@searchValue = N'') or (CategoryName like @searchValue)

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
                        data.Add(new Category()
                        {
                            CategoryID = Convert.ToInt32(dbReader["CategoryID"]),
                            CategoryName = Convert.ToString(dbReader["CategoryName"]),
                            Description = Convert.ToString(dbReader["Description"]),
                        });
                    }

                }
                connection.Close();
            }
            return data;
            
        }

        public bool Update(Category date)
        {
            throw new NotImplementedException();
        }
    }
}
