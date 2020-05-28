using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISupplierDAL
    {
        /// <summary>
        /// Hiển thị danh sách Supplier,phân trang và có thể tìm kiếm
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<SuppliSer> List(int page, int pageSize, string searchValue);
        
    
        /// <summary>
        /// đếm số Supplier trong ds
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy Supplier
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        SuppliSer Get(int supplierID);
        /// <summary>
        /// Bổ sung 1 supplier , hàm trả về ID của supplier được bổ sung
        /// nếu lỗi m hàm trả về giá trị nhỏ hơn hoặc bằng 0
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(SuppliSer data);
        /// <summary>
        /// Sửa 1 supplier
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        bool Update(SuppliSer date);
        /// <summary>
        /// Xóa nhiếu supplier 
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        int Detele(int[] supplierIDs);
    }
}
