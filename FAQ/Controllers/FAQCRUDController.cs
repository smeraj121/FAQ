using FAQ.Models;
using FAQ.Services;
using System.Web.Mvc;

namespace FAQ.Controllers
{
    public class FAQCRUDController : Controller
    {
        FAQCRUDServices crudService = new FAQCRUDServices();
        CategoryServices categoryServices = new CategoryServices();


        public ActionResult AddFAQ(int id)//categoryID
        {
            Categories category = categoryServices.GetCategoryByID(id);
            FAQuestions question = new FAQuestions()
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                SiteCode = category.SiteCode
            };
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFAQ(FAQuestions question)
        {
            int result = crudService.AddFAQ(question);
            if (result > 0)
            {
                TempData["Success"] = "Successfully Added";
                return RedirectToAction("Edit", new { id = result });
            }
            else
            {
                ViewBag.Success = "Attempt failed";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)//questionid
        {
            FAQuestions question = crudService.GetQuestion(id);
            ViewBag.Success = TempData["Success"] as string;
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuestion(FAQuestions question)
        {
            bool result = crudService.EditQuestion(question);
            int id = question.QuestionID;
            if (result)
            {
                ViewBag.Success = "Successfully Saved";
            }
            else
            {
                ViewBag.Success = "Operation Failed";
            }
            return RedirectToAction("Edit",new { id = id });
        }

        public string Hide(int id,int val)
        {
            crudService.HideQuestion(id,val);
            return "true"; }

        public ActionResult Delete(int id, int categoryid)//question id
        {
            crudService.DeleteQuestion(id);
            return RedirectToAction("FAQList","FAQuestion",new { id = categoryid });
        }
    }
}