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
    public class ProductDAL : IProductDAL
    {
        private string connectionString;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="connectionString"></param>
        public ProductDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add(Product data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }

        public int Detele(int[] productIDs)
        {
            throw new NotImplementedException();
        }

        public Product Get(int ProductID)
        {
            throw new NotImplementedException();
        }

        public List<Product> List(int page, int pageSize, string searchValue)
        {
            List<Product> data = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //tạo lệnh thực thi truy vấn dữ liệu
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Products";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        data.Add(new Product()
                        {
                            ProductID = Convert.ToInt32(dbReader["ProductID"]),
                            SupplierID = Convert.ToInt32(dbReader["SupplierID"]),
                            CategoryID = Convert.ToInt32(dbReader["CategoryID"]),
                            ProductName = Convert.ToString(dbReader["ProductName"]),
                            Descriptions = Convert.ToString(dbReader["Descriptions"]),
                            QuantityPerUnit = Convert.ToString(dbReader["QuantityPerUnit"]),
                            UnitPrice = Convert.ToString(dbReader["UnitPrice"]),
                            PhotoPath = Convert.ToString(dbReader["PhotoPath"]),




                        });
                    }

                }
                connection.Close();
            }
            return data;
        }

        public bool Update(Product date)
        {
            throw new NotImplementedException();
        }
    }
}
