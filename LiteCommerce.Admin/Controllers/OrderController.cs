using LiteCommerce.Admin.Models;
using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize(Roles =WebUserRoles.STAFF)]
    public class OrderController : Controller
    {

        // GET: Order
        public ActionResult Index(int page = 1, string searchValue = "", string ShipperCountry = "")
        {

            int pageSize = 5;
            int rowCount = 0;
            List<OrderNameToID> ListOfOrder = OrderBLL.ListOfOrders(page, pageSize, searchValue, ShipperCountry, out rowCount);
            var model = new OrderPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                ShipperCountry = ShipperCountry,
                Data = ListOfOrder

            };
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}