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
        List<Product> List(int page, int pageSize, string searchValue);
        int Count(string searchValue);
        Product Get(int ProductID);
        int Add(Product data);
        bool Update(Product date);
        int Detele(int[] productIDs);
    }
}
