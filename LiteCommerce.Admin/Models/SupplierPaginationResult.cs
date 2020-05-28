using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    public class SupplierPaginationResult : PaginationResult
    {
    /// <summary>
    ///danh sách supplier
    /// </summary>
        public List<SuppliSer> Data { get; set; }
    }
}