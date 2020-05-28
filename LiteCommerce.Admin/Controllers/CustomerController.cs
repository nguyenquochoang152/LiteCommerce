using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
       
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 10;
            int rowCount = 0;
            List<Customer> ListOfCustomer = CatalogBLL.ListOfCustomers(page, pageSize, searchValue, out rowCount);
            var model = new Models.CustomerPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                Data = ListOfCustomer
            };
            return View(model);
        }
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Create new Customer";
            }
            else
            {
                ViewBag.Title = "Edit a Customer";
            }
            return View();
        }
    }
}