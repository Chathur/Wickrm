using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class Report_TestController : Controller
    {
        private WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        // GET: Report_Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Export(tb_SalesOrder sales)
        {
            ReportDocument rd = new ReportDocument();
            ParameterField paramField = new ParameterField();


            rd.Load(Path.Combine(Server.MapPath("~/Reports/Report_test.rpt")));
            rd.SetDataSource(db.tb_SalesOrder.Select(p => new
            {
                Bill_No = p.Bill_No,
                Date = p.Date,
                Name_Product = p.Name_Product,
                Quantity = p.Quantity,
                Total = p.Total,
                Price = p.Price
            }).ToList());

            rd.SetParameterValue("Bill_No", sales.Bill_No);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "DailySales.pdf");

        }
    }
}