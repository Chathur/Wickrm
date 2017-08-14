using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_MVC5.Models;
using Project_MVC5.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

namespace Project_MVC5.Controllers { 

    public class Report_SalesDailyController : Controller
    {
        // GET: Report_SalesDaily
        private Demo_onlineEntities db = new Demo_onlineEntities();
        



        /// <summary>
        /// ///////////// First clear temporary table of the database rows (see carts controller clear method)
        /// ///////////// Then Add items to temporary table
        /// ////////////  Use it to generate the report 
        /// </summary>
        /// <returns></returns>

        public ActionResult Index()
        {
            
            ViewBag.ListSales = db.tb_Sales.ToList();
            return View();
        }



        public ActionResult Export(tb_Sales sales)
        {
            ReportDocument rd = new ReportDocument();
            ParameterField paramField = new ParameterField();
            

            rd.Load(Path.Combine(Server.MapPath("~/Reports/Report_SalesDaily.rpt")));
            rd.SetDataSource(db.tb_Sales.Select(p => new
            {
                Bill_No = p.Bill_No,
                Date = p.Date,
                Name_Product = p.Name_Product,
                Quantity = p.Quantity,
                Total=p.Total,
                Price = p.Price
            }).ToList());

            rd.SetParameterValue("Bill_No", sales.Bill_No);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0,SeekOrigin.Begin);
            return File(stream, "application/pdf", "DailySales.pdf");
           
        }
    }
}