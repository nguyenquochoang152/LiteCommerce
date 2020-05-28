using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using LiteCommerce.BusinessLayers;

namespace LiteCommerce.Admin
{
    public class BusinessLayerConfig
    {
        public static void Init()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LiteCommerce"].ConnectionString;
            //TODO : Khởi tạo các BLL Khi cần sử dụng
            CatalogBLL.Initialize(connectionString);
            EmployeeBLL.Initialize(connectionString);
        }
    }
}