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
    public class ShipperController : Controller
    {
        // GET: Shipper
    
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 10;
            int rowCount = 0;
            List<Shipper> ListOfShipper = CatalogBLL.ListOfShippers(page, pageSize, searchValue, out rowCount);
            var model = new Models.ShipperPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                Data = ListOfShipper,
            };
            return View(model);
        }

        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Create new Shipper";
            }
            else
            {
                ViewBag.Title = "Edit a Shipper";
            }
            return View();
        }
    }
}