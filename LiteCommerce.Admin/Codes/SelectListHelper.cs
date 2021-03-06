﻿using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin
{
    public static class SelectListHelper
    {
        /// <summary>
        /// Các quốc gia 
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Countries(bool allSelectAll = true)
        {
            List<Country> getList = new List<Country>();
            getList = CountryBLL.GetList();
            List<SelectListItem> List = new List<SelectListItem>();
            if (allSelectAll)
            {
                List.Add(new SelectListItem() { Value = "", Text = "-- All Countries --" });

            }
            foreach (var country in getList)
            {
                List.Add(new SelectListItem { Value = country.Abbreviation, Text = country.CountryName });
            }
            return List;
        }
        public static List<SelectListItem> Categories(bool allSelectAll = true)
        {
            List<Category> getAll = new List<Category>();
            getAll = CatalogBLL.GetAllCategories();
            List<SelectListItem> List = new List<SelectListItem>();
            if (allSelectAll)
            {
                List.Add(new SelectListItem() { Value = "", Text = "-- All Categories --" });

            }
            foreach (var category in getAll)
            {
                List.Add(new SelectListItem() { Value = category.CategoryID.ToString(), Text = category.CategoryName });
            }
            return List;

        }
        public static List<SelectListItem> Suppliers(bool allSelectAll = true)
        {
            List<SuppliSer> getAll = new List<SuppliSer>();
            getAll = CatalogBLL.GetAllSuppliers();
            List<SelectListItem> List = new List<SelectListItem>();
            if (allSelectAll)
            {
                List.Add(new SelectListItem() { Value = "", Text = "-- All Suppliers --" });

            }
            foreach (var supplier in getAll)
            {
                List.Add(new SelectListItem() { Value = supplier.SupplierID.ToString(), Text = supplier.CompanyName });
            }
            return List;

        }
    }
}