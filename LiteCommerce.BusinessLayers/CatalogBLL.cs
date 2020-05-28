using LiteCommerce.DataLayers;
using LiteCommerce.DataLayers.SqlServer;
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
        private static IShipperDAL ShipperDB { get; set; }
        private static ICustomerDAL CustomerDB { get; set; }
        private static CategoryDAL CategoryDB { get; set; }
        private static ProductDAL ProductDB { get; set; }
       
        public static void Initialize(string connectionString)
        {
            ShipperDB = new DataLayers.SqlServer.ShipperDAL(connectionString);
            SupplierDB = new DataLayers.SqlServer.SupplierDAL(connectionString);
            CustomerDB = new DataLayers.SqlServer.CustomerDAL(connectionString);
            CategoryDB = new DataLayers.SqlServer.CategoryDAL(connectionString);
            ProductDB = new DataLayers.SqlServer.ProductDAL(connectionString);
        }
        #region khai báo các chức năng xử lý nghiệp vụ
        public static List<SuppliSer> ListOfSuppliers(int page,int pageSize, string searchValue,out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = SupplierDB.Count(searchValue);
            return SupplierDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// lấy 1 supplier
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static SuppliSer GetSupplier(int supplierID)
        {
            return SupplierDB.Get(supplierID);
        }
        /// <summary>
        /// thêm 1 supplier
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(SuppliSer data)
        {
            return SupplierDB.Add(data);
        }
        /// <summary>
        /// sửa 1 supplier
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(SuppliSer data)
        {
            return SupplierDB.Update(data);
        }
        /// <summary>
        /// xóa nhiều supplier
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static int DeleteSuppliers(int[] supplierID)
        {
            return SupplierDB.Detele(supplierID);
        }
        public static List<Shipper> ListOfShippers(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = ShipperDB.Count(searchValue);
            return ShipperDB.List(page, pageSize, searchValue);
        }
       
        public static List<Product> ListOfProducts(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = ProductDB.Count(searchValue);
            return ProductDB.List(page, pageSize, searchValue);
        }
        public static List<Customer> ListOfCustomers(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = CustomerDB.Count(searchValue);
            return CustomerDB.List(page, pageSize, searchValue);
        }
        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = CategoryDB.Count(searchValue);
            return CategoryDB.List(page, pageSize, searchValue);
        }
        #endregion
    }
}
