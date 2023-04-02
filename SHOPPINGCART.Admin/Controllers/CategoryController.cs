using System.Collections.Generic;
using System.Web.Mvc;
using SHOPPINGCART.Application.Services;
using SHOPPINGCART.Domain.Entities;

namespace SHOPPINGCART.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Maintainer
        public ActionResult Category()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListCategories()
        {
            List<Category> oListCategory = new List<Category>();
            oListCategory = new CategoryService().Lists();
            return Json(new { data = oListCategory }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveCategory(Category category)
        {
            object result;
            string message = string.Empty;
            if (category.CategoryId == 0)
            {
                result = new CategoryService().Register(category, out message);
            }
            else
            {
                result = new CategoryService().Edit(category, out message);
            }
            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCategory(int categoryId)
        {
            bool result = false;
            string message = string.Empty;
            result = new CategoryService().Delete(categoryId, out message);
            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}

