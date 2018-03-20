using FAQ.Models;
using FAQ.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;

namespace FAQ.Controllers
{
    public class FAQuestionController : Controller
    {
        FAQuestionService faqService = new FAQuestionService();
        CategoryServices categoryServices = new CategoryServices();
        // GET: FAQuestion
        public ActionResult FAQList(int id,int? Page)//categoryid
        {
            List<FAQuestions> faqlist=faqService.GetFAQListOnCategory(id);
            ViewBag.ID = id;
            if (faqlist.Count>0)
            {
                ViewBag.CategoryName = faqlist[0].CategoryName;
                ViewBag.SiteCode = faqlist[0].SiteCode;
            }
            return View(faqlist.ToPagedList(Page ?? 1,4));
        }

        public ActionResult Order(int id,int value,int backto)
        {
            if (value==-1)
            {
                faqService.ShiftUP(id,backto);
            }
            else
            {
                faqService.ShiftDown(id,backto);
            }
            return RedirectToAction("FAQList", new { id = backto });
        }
    }
}