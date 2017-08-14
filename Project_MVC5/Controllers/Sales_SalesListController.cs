using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_MVC5.Models;

namespace Project_MVC5.Controllers
{
    public class Sales_SalesListController : Controller
    {
        // GET: Sales_SalesList
        private WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SalesList()
        {
            return View(db.tb_Sales.ToList());
        }
    }
}