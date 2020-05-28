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
    public class ShipperDAL : IShipperDAL
    {
        private string connectionString;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="connectionString"></param>
        public ShipperDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add(Shipper data)
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
                cmd.CommandText = @"select count(*) from Shippers where @searchValue =N''or CompanyName like @searchValue";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                count = Convert.ToInt32(cmd.ExecuteScalar());

                connection.Close();
            }



            return count;
        }

        public int Detele(int[] shipperIDs)
        {
            throw new NotImplementedException();
        }

        public Shipper Get(int shipperID)
        {
            throw new NotImplementedException();
        }

        public List<Shipper> List(int page, int pageSize, string searchValue)
        {
            List<Shipper> data = new List<Shipper>();
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
	                                    SELECT ROW_NUMBER() OVER(ORDER BY CompanyName) as RowNumber,Shippers.*
	                                    from Shippers
	                                    where (@searchValue = N'') or (CompanyName like @searchValue)

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
                        data.Add(new Shipper()
                        {
                            ShipperID = Convert.ToInt32(dbReader["ShipperID"]),
                            CompanyName = Convert.ToString(dbReader["CompanyName"]),
                            Phone = Convert.ToString(dbReader["Phone"]),
                        });
                    }

                }
                connection.Close();
            }
            return data;
        }

        public bool Update(Shipper date)


        {
            throw new NotImplementedException();
        }
    }
}
