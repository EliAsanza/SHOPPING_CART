using SHOPPINGCART.Application;
using SHOPPINGCART.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public JsonResult ListsUsers()
        {
            List<User> oList = new List<User>();

            oList = new UserService().Lists();

            return Json(oList,JsonRequestBehavior.AllowGet);
        
        }







    }
}