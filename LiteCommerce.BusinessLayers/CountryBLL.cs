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
    public class CountryBLL
    {
        private static ICountryDAL CountryDB;

        public static void Initialize(string connectionString)
        {
            CountryDB = new CountryDAL(connectionString);
        }
        public static List<Country> GetList()
        {   
            return CountryDB.getAll();
        }
        public static List<Country> ListOfCountries(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = CountryDB.Count(searchValue);
            return CountryDB.List(page, pageSize, searchValue);
        }
        public static Country GetCountry(int countryId)
        {
            return CountryDB.Get(countryId);
        }
        /// <summary>
        /// thêm 1 category
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCountry(Country data)
        {
            return CountryDB.Add(data);
        }
        /// <summary>
        /// sửa 1category
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCountry(Country data)
        {
            return CountryDB.Update(data);
        }
        /// <summary>
        /// xóa nhiều category
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static int DeleteCountries(int[] countryId)
        {
            return CountryDB.Detele(countryId);
        }
    }
}
