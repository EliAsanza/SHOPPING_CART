using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOPPINGCART.Admin.Controllers
{
    public class AccesController : Controller
    {
        // GET: Acces
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassaword()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}
