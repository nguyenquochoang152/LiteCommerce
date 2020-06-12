using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models.Attribute
{
    public class ProductAttributeModel
    {
        public int ProductID { get; set; }
        public List<DomainModels.ProductAttribute> ListProductAttributes { get; set; }
    }
}