using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class Sales_CustomerController : Controller
    {
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        // GET: PurchaseGRN
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sales_Customer()
        {
            return View(db.tb_Customer.OrderByDescending(p => p.ID_Customer).ToList());
        }
        public ActionResult AddorEdit(tb_Customer cu,Route ru)
        {
            Route routes = new Route();
            if (cu.ID_Customer == 0) // Add new
            {
                tb_Customer cus = new tb_Customer();
                cus.Name_Customer = cu.Name_Customer;
                cus.Address_Customer = cu.Address_Customer;
                cus.Tel_Customer = cu.Tel_Customer;
                cus.CreditLimit = cu.CreditLimit;
                cus.Route_Customer = db.Route.Where(p => p.Route_desc == ru.Route_desc).Select(x => x.Route_id).First();
                db.tb_Customer.Add(cus);
                db.SaveChanges();

            }

            else // edit
            {
                var update = db.tb_Customer.Find(cu.ID_Customer);
                update.Name_Customer = cu.Name_Customer;
                update.Address_Customer = cu.Address_Customer;
                update.CreditLimit = cu.CreditLimit;
                update.Tel_Customer = cu.Tel_Customer;

            }
            db.SaveChanges();

            return RedirectToAction("Sales_Customer", "Sales_Customer");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.tb_Customer.Where(p => p.ID_Customer == id).First();
            db.tb_Customer.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Sales_Customer", "Sales_Customer");
        }
    }
}