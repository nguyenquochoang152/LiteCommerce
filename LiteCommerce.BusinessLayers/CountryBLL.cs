﻿using LiteCommerce.DataLayers;
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
        public static List<Country> getList()
        {   
            return CountryDB.getAll();
        }
    }
}
