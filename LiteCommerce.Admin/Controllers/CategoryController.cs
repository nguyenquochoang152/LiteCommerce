using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
       
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 5;
            int rowCount = 0;
            List<Category> ListOfSupplier = CatalogBLL.ListOfCategories(page, pageSize, searchValue, out rowCount);
            var model = new Models.CategoryPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                Data = ListOfSupplier
            };
            return View(model);
        }
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Create new Categorys";
            }
            else
            {
                ViewBag.Title = "Edit a Categorys";
            }
            return View();
        }
    }
}