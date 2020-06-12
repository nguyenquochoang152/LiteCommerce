using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IProductAttributesDAL
    {
        List<ProductAttribute> getAll(int productID);
        int Delete(int[] AttributeIDs);
        int Update(List<ProductAttribute> data);
        int Add(List<ProductAttribute> data);
        bool CheckProductInAttibute(int ProductID);
    }
}
