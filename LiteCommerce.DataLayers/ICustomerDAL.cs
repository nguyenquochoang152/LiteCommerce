using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface ICustomerDAL
    {
        List<Customer> List(int page, int pageSize, string searchValue);
        int Count(string searchValue);
        Customer Get(string CustomerID);
        int Add(Customer data);
        bool Update(Customer data);
        int Detele(string[] customerIDs);
    }
}
