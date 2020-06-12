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
    public class ProductAttributeBLL
    {
        private static IProductAttributesDAL ProductAttributeDB;
        public static void Initialize(string connectionString)
        {
            ProductAttributeDB = new ProductAttributeDAL(connectionString);
        }
        public static List<ProductAttribute> getAll(int productID)
        {
            return ProductAttributeDB.getAll(productID);
        }
        public static int Add(List<ProductAttribute> ProductAttribute)
        {
            return ProductAttributeDB.Add(ProductAttribute);
        }
        public static int Update(List<ProductAttribute> ProductAttribute)
        {
            return ProductAttributeDB.Update(ProductAttribute);
        }
        public static int Delete(int[] ProductAttributes)
        {
            return ProductAttributeDB.Delete(ProductAttributes);
        }
    }
}
