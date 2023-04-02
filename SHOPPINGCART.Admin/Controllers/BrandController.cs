using System.Collections.Generic;
using System.Web.Mvc;
using SHOPPINGCART.Application.Services;
using SHOPPINGCART.Domain.Entities;

namespace SHOPPINGCART.Admin.Controllers
{
    public class BrandController : Controller
    {
        // GET: Maintainer
        public ActionResult Brand()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListBrands()
        {
            List<Brand> oListBrand = new List<Brand>();
            oListBrand = new BrandService().Lists();
            return Json(new { data = oListBrand }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveBrand(Brand brand)
        {
            object result;
            string message = string.Empty;
            if (brand.BrandId == 0)
            {
                result = new BrandService().Register(brand, out message);
            }
            else
            {
                result = new BrandService().Edit(brand, out message);
            }
            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteBrand(int brandId)
        {
            bool result = false;
            string message = string.Empty;
            result = new BrandService().Delete(brandId, out message);
            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}