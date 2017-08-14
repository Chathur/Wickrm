using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class Sales_SalesOrderController : Controller
    {
        // GET: Sales_SalesOrder
        Demo_onlineEntities db = new Demo_onlineEntities();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SalesOrder()
        {
            return View(db.tb_SalesOrder.OrderByDescending(p => p.ID_Product).ToList());
        }
        public ActionResult AddorEdit(tb_SalesOrder pr)
        {

            // Add new
            if (pr.ID_Product == 0)
            {
                tb_SalesOrder pro = new tb_SalesOrder();
                pro.Name_Product = pr.Name_Product;
                pro.Price = pr.Price;
                pro.Quantity = pr.Quantity;
                pro.Bill_No = pr.Bill_No;
                // pro.Code_Product = pr.Code_Product;
                pro.Customer = pr.Customer;
                pro.Date = pr.Date;
                pro.Employee = pr.Employee;
                db.tb_SalesOrder.Add(pro);
            }
            else
            {
                var update = db.tb_SalesOrder.Find(pr.ID_Product);

                update.Name_Product = pr.Name_Product;
                update.Price = pr.Price;
                update.Quantity = pr.Quantity;
                update.Bill_No = pr.Bill_No;
                // pro.Code_Product = pr.Code_Product;
                update.Customer = pr.Customer;
                update.Date = pr.Date;
                update.Employee = pr.Employee;

            }

            db.SaveChanges();

            return RedirectToAction("SalesOrder", "Sales_SalesOrder");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.tb_SalesOrder.Where(p => p.ID_Product == id).First();
            db.tb_SalesOrder.Remove(delete);
            db.SaveChanges();
            
            return RedirectToAction("SalesOrder", "Sales_SalesOrder");
        }
        

    }
}