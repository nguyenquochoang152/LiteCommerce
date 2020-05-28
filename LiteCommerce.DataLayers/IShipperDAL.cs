using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IShipperDAL
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="searchValue"></param>
    /// <returns></returns>
        List<Shipper> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        Shipper Get(int shipperID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Shipper data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        bool Update(Shipper date);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperIDs"></param>
        /// <returns></returns>
        int Detele(int[] shipperIDs);
    }
}
