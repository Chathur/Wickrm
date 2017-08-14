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
    public class Report_SalesOrderController : Controller
    {
        // GET: Report_SalesOrder
        private Demo_onlineEntities db = new Demo_onlineEntities();
        public ActionResult Index()
        {

           
            return View();
        }



        public ActionResult Export(tb_SalesOrder salesOrder)
        {
            ReportDocument rd = new ReportDocument();
           // ParameterField paramField = new ParameterField();


            rd.Load(Path.Combine(Server.MapPath("~/Reports/Report_SalesOrder.rpt")));
            rd.SetDataSource(db.tb_SalesOrder.Select(p => new
            {
                
                Name_Product = p.Name_Product,
                Quantity = p.Quantity,
                Price=p.Price,

                
            }).ToList());

           // rd.SetParameterValue("Bill_No", sales.Bill_No);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Loading Report.pdf");

        }
    }
}