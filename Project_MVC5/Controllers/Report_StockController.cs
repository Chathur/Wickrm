using CrystalDecisions.CrystalReports.Engine;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class Report_StockController : Controller
    {

        // Stock and valuation report generation methods are available here

        private WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Export(ITEMS items)
        {
            ReportDocument rd = new ReportDocument();
            // ParameterField paramField = new ParameterField();


            rd.Load(Path.Combine(Server.MapPath("~/Reports/Report_Stock.rpt")));
            rd.SetDataSource(db.ITEMS
                .Where(p=>p.STOCK_LEVEL>0)
                .Select(p => new
            {

                Name_Item = p.Name_Item,
                STOCK_LEVEL = p.STOCK_LEVEL


            }).ToList());

            // rd.SetParameterValue("Bill_No", sales.Bill_No);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Stock Report.pdf");

        }

        public ActionResult ExportValuation(ITEMS items)
        {
            ReportDocument rd = new ReportDocument();
            // ParameterField paramField = new ParameterField();


            rd.Load(Path.Combine(Server.MapPath("~/Reports/Report_Valuation.rpt")));
            rd.SetDataSource(db.ITEMS
                .Where(p => p.STOCK_LEVEL > 0)
                .Select(p => new
            {

                Name_Item = p.Name_Item,
                STOCK_LEVEL = p.STOCK_LEVEL,
                COST_PRICE = p.COST_PRICE


            }).ToList());

            // rd.SetParameterValue("Bill_No", sales.Bill_No);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Valuation Report.pdf");

        }
    }
}