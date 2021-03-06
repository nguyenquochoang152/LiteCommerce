﻿using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface ICountryDAL
    {
        List<Country> List(int page, int pageSize, string searchValue);
        int Count(string searchValue);
        Country Get(int CountryID);
        int Add(Country data);
        bool Update(Country data);
        int Detele(int[] countryIDs);
        List<Country> getAll();
    }
}
