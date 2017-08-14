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
    public class Report_TransactionDetailsController : Controller
    {
        // GET: Report_TransactionDetails
        private WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Export(tb_SalesOrder salesorder)
        {
            ReportDocument rd = new ReportDocument();
            // ParameterField paramField = new ParameterField();


            rd.Load(Path.Combine(Server.MapPath("~/Reports/Report_TransactionDetails.rpt")));
            rd.SetDataSource(db.tb_SalesOrder
                 .Select(p => new
                {
                     Date=p.Date,
                     //End_Date = p.End_Date,
                     Bill_No = p.Bill_No,
                     Customer = p.Customer,
                     Employee = p.Employee,
                     Route = p.Route,
               }).ToList());

            rd.SetParameterValue("End_Date", salesorder.End_Date);
            rd.SetParameterValue("Start_Date", salesorder.Start_Date);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "TransactionDetails Report.pdf");

        }
    }
}