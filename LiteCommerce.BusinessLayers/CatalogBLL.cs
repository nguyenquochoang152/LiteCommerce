using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.BusinessLayers
{
    /// <summary>
    /// Các chức năng xử lý nghiệp vụ liên quan đến
    /// quản lý dữ liệu chung của hệ thống như: nhà cung cấp, khách hàng, mặt hàng///
    /// </summary>
    
    public static class CatalogBLL
    {
        private static ISupplierDAL SupplierDB { get; set; }
        public static void Initialize(string connectionString)
        {
            SupplierDB = new DataLayers.SqlServer.SupplierDAL(connectionString);
        }
        #region khai báo các chức năng xử lý nghiệp vụ
        public static List<Supplier> ListOfSuppliers(int page,int pageSize, string searchValue,out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = SupplierDB.Count(searchValue);
            return SupplierDB.List(page, pageSize, searchValue);
        }
        #endregion
    }
}
