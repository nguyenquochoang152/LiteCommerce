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
    public class OrderBLL
    {
        /// <summary>
        ///  Hàm phải được gọi để khởi tạo chức năng tác nghiệp
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            OrderDB = new OrderDAL(connectionString);
        }
        #region Khai báo các thuộc tính giao tiếp với DAL

        private static IOrderDAL OrderDB { get; set; }

        #endregion

        #region Khai báo các chức năng xử lý nghiệp vụ
        /// <summary>
        /// Hiển thị danh sách của emloyee
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<OrderNameToID> ListOfOrders(int page, int pageSize, string searchValue, string country, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = OrderDB.Count(searchValue, country);
            return OrderDB.List(page, pageSize, searchValue, country);
        }

        /// <summary>
        /// Lấy 1 Order 
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static OrderNameToID GetOrder(int OrderID)
        {
            return OrderDB.Get(OrderID);
        }
        /// <summary>
        /// thêm 1 Order
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddOrder(Order data)
        {
            return OrderDB.Add(data);
        }
        /// <summary>
        /// xóa 1 danh sách Order
        /// </summary>
        /// <param name="OrderIDs"></param>
        /// <returns></returns>
        public static int DeleteOrders(int[] OrderIDs)
        {
            return OrderDB.Delete(OrderIDs);
        }
        /// <summary>
        /// update 1 Order
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateOrder(Order data)
        {
            return OrderDB.Update(data);
        }
       
        #endregion
    }
}
