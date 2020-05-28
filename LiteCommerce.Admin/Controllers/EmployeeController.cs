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
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Employee> ListOfEmployees =  EmployeeBLL.ListOfEmployees(page, pageSize, searchValue, out rowCount);
            var model = new Models.EmployeePaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                Data = ListOfEmployees,
            };
            return View(model);
        }
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Create new Employees";
            }
            else
            {
                ViewBag.Title = "Edit a Employees";
            }
            return View();
        }
    }
}