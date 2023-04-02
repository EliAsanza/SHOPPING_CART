using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Newtonsoft.Json;
using SHOPPINGCART.Application.Services;
using SHOPPINGCART.Domain.Entities;

namespace SHOPPINGCART.Admin.Controllers
{
    public class ProductController: Controller
    {
        public ActionResult Product()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListProducts()
        {
            List<Product> oListProduct = new List<Product>();
            oListProduct = new ProductService().Lists();
            return Json(new { data = oListProduct }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveProduct(string objecto, HttpPostedFileBase archivoImage)
        {
            string message = string.Empty;
            bool successful_Operation = true;
            bool save_Successful_Image = true;

            Product oProduct = new Product();
            oProduct = JsonConvert.DeserializeObject<Product>(objecto); //COnivierto el objeto  en oProdcuto
            decimal price;

            if (decimal.TryParse(oProduct.PriceText, NumberStyles.AllowDecimalPoint, new CultureInfo("es-SP"), out price))
            {
                oProduct.Price = price;
            }
            else
            {
                return Json(new { successfulOperation = false, message = "The price format must be ##.##" }, JsonRequestBehavior.AllowGet);
            }


            if (oProduct.ProductId == 0)
            {
                int productIdGenerated = new ProductService().Register(oProduct, out message);
                if (productIdGenerated !=0)
                {
                    oProduct.ProductId = productIdGenerated;
                }
                else
                {
                    successful_Operation = false;
                }
            }
            else
            {
                successful_Operation = new ProductService().Edit(oProduct, out message);
            }

            if (successful_Operation)
            {
                if (archivoImage !=null)
                {
                    string ruta_save = ConfigurationManager.AppSettings["ServerPhotos"];
                    string extension = Path.GetExtension(archivoImage.FileName);
                    string nameImagen = string.Concat(oProduct.ProductId.ToString(), extension);

                    try
                    {
                        archivoImage.SaveAs(Path.Combine(ruta_save, nameImagen));
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        save_Successful_Image = false;
                    }

                    if (save_Successful_Image)
                    {
                        oProduct.ImagePath = ruta_save;
                        oProduct.ImageName = nameImagen;
                        bool rspta = new ProductService().SaveImageData(oProduct, out message);
                    }
                    else 
                    { 
                        message = "The product was saved, but there were problems with the image"; 
                    }
                }
            }
            return Json(new { successfulOperation = successful_Operation, idGenerated = oProduct.ProductId, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteProduct(int productId)
        {
            bool result = false;
            string message = string.Empty;
            result = new ProductService().Delete(productId, out message);
            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

    }
}