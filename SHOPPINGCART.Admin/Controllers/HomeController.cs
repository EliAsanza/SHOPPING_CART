using SHOPPINGCART.Application;
using SHOPPINGCART.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SHOPPINGCART.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListsUsers()
        {
            List<User> oList = new List<User>();

            oList = new UserService().Lists();

            return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveUser(User objeto)
        {
            object result;
            string Message = string.Empty;

            if (objeto.UserId == 0)
            {
                result = new UserService().Register(objeto, out Message);
            }
            else
            {
                result = new UserService().Edit(objeto, out Message);
            }
            return Json(new {resultt = result, message = Message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            bool resp = false;
            string message = string.Empty;
            resp = new UserService().Delete(id, out message);

            return Json(new { resultt = resp, message = message }, JsonRequestBehavior.AllowGet);
        }

    }
}