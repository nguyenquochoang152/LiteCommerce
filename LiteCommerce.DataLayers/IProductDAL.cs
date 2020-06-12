using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IProductDAL
    {
        List<Product> List(int page, int pageSize, string searchValue, string Category, string SuppliSer);
        int Count(string searchValue, string Category, string SuppliSer);
        Product Get(int ProductID);
        int Add(Product data);
        bool Update(Product date);
        int Detele(int[] productIDs);
    }
}
