﻿using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IOrderDAL
    {
        /// <summary>
        /// Hiển thị danh sách Order ,phân trang và tìm kiếm
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<OrderNameToID> List(int page, int pagesize, string searchValue, string shipCountry);
        /// <summary>
        /// Đếm số lượng Order
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue, string country);
        /// <summary>
        /// Lấy Order
        /// </summary>
        /// <returns></returns>
        OrderNameToID Get(int orderID);
        /// <summary>
        /// Thêm Order.Hàm trả về ID Order được bổ sung.
        /// Nếu lỗi ,hàm trả về giá trj nhỏ hơn hoặc bằng 0.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Order data);
        /// <summary>
        /// Sữa đỗi 1 Order.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Order data);
        /// <summary>
        /// Xóa nhiều Order.
        /// Trả về số lượng được xóa.
        /// </summary>
        /// <param name="orderIDs"></param>
        /// <returns></returns>
        int Delete(int[] orderIDs);
        List<OrderDetail> GetAll(int OrderID);
        string CustomerNameToID(string CustomerName);
        int EmployeeNametoID(string EmployeeName);
        int ShipperNametoID(string ShipperName);
        
    }
}
