using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace Project_MVC5.Controllers
{
    public class Test_reportController : Controller
    {
        // GET: Test_report
        public ActionResult Index()
        {
            return View();
        }
        public void ShowSimple()
        {
            using (ReportDocument rptH = new ReportDocument())
            {
                rptH.FileName = Server.MapPath("~/Reports/Report_SalesDaily.rpt");
                rptH.Load(Path.Combine(Server.MapPath("~/Reports/Report_SalesDaily.rpt")));
                rptH.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
            }
        }
    }
}