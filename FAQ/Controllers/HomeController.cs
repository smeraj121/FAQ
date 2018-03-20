using FAQ.Models;
using FAQ.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FAQ.Controllers
{
    public class HomeController : Controller
    {
        DropDownService dropdown = new DropDownService();
        CategoryServices categoryServices = new CategoryServices();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ListItems = new SelectList(dropdown.GetItem(),"SiteCode","Category");
            List<Categories> listCategories = categoryServices.GetCategoryBySelectedItem(1);
            return View(listCategories);
        }
        [HttpPost]
        public ActionResult Index(int categories)
        {
            ViewBag.ListItems = new SelectList(dropdown.GetItem(), "SiteCode", "Category");
            List<Categories> listCategories = categoryServices.GetCategoryBySelectedItem(categories);
            return View(listCategories);
        }
    }
}