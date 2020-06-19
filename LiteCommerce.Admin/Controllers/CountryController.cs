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
    
    public class CountryController : Controller
    {
        
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 5;
            int rowCount = 0;
            List<Country> ListOfCountry = CountryBLL.ListOfCountries(page, pageSize, searchValue, out rowCount);
            var model = new Models.CountryPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                Data = ListOfCountry
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult Input(string id = "")
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    ViewBag.Title = "Create new Country";
                    Country newSupplier = new Country()
                    {
                        CountryID = 0
                    };
                    return View(newSupplier);
                }
                else
                {
                    ViewBag.Title = "Edit a Country";
                    Country editCountry = CountryBLL.GetCountry(Convert.ToInt32(id));
                    if (editCountry == null)
                        return RedirectToAction("Index");
                    return View(editCountry);
                }
            
            }
            catch (Exception ex)
            {
                return Content(ex.Message + ":" + ex.StackTrace);
            }
        }
        [HttpPost]
        public ActionResult Input(Country model)
        {
            try
            {
                //TODO:
                if (string.IsNullOrEmpty(model.CountryName))
                
                    ModelState.AddModelError("CountryName", "CategoryName expected");
                
                if (string.IsNullOrEmpty(model.Abbreviation))
                    model.Abbreviation = "";

                if (model.CountryID == 0)
                {
                    CountryBLL.AddCountry(model);

                }
                else
                {
                    CountryBLL.UpdateCountry(model);
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ":" + ex.StackTrace);
                return View(model);
            }
        }

        public ActionResult Delete(int[] CountryIDs = null)
        {
            if (CountryIDs != null)
            {
                CountryBLL.DeleteCountries(CountryIDs);

            }
            return RedirectToAction("Index");
        }
    }
}