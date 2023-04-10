using ClosedXML.Excel;
using SHOPPINGCART.Application.Services;
using SHOPPINGCART.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SHOPPINGCART.Admin.Controllers
{
    public class DashBoardReportController: Controller
    {
        public ActionResult DashBoardReport()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListReports(string startDate, string endingDate, string transactionId)
        {
            List<Reports> oList = new List<Reports>();

            oList = new DashBoardReportService().Sales(startDate, endingDate, transactionId);
            return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ViewDashBoard()
        {
            DashBoard objeto = new DashBoardReportService().ViewDashBoard();
            return Json(new {result = objeto}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public FileResult SaleExport(string startDate, string endingDate, string transactionId)
        {
            List<Reports> oList = new List<Reports>();
            oList = new DashBoardReportService().Sales(startDate, endingDate, transactionId);
            DataTable dt = new DataTable();
            dt.Locale = new System.Globalization.CultureInfo("es-SP");
            dt.Columns.Add("SaleDate", typeof(string));
            dt.Columns.Add("Customer", typeof(string));
            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("AQuantity", typeof(int));
            dt.Columns.Add("SubTotal", typeof(decimal));
            dt.Columns.Add("TotalAmount", typeof(decimal));
            dt.Columns.Add("TransactionId", typeof(string));

            foreach (Reports rp in oList) //Recorre cada elemento de la lista 
            {
                dt.Rows.Add(new object[]
                {
                    rp.Saledate,
                    rp.Customer,
                    rp.Product,
                    rp.Price,
                    rp.Quantity,
                    rp.Subtotal,
                    rp.TotalAmount,
                    rp.TransactionId
                });
            }

            dt.TableName = "Datos";  //

            using(XLWorkbook wb = new XLWorkbook()) // configuracion de exportar 
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportstSale" + DateTime.Now.ToString() + ".xlsx"); //Descargamos el archivo excel
                }

            }





        }
    }
}