using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_MVC5.Models;

namespace Project_MVC5.Controllers
{
    public class Test_SalesController : Controller
    {
        private Demo_onlineEntities db = new Demo_onlineEntities();

        // GET: Test_Sales
        public ActionResult Index()
        {
            return View(db.tb_Sales.ToList());
        }

    }
}
