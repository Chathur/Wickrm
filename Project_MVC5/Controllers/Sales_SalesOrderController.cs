using Microsoft.Ajax.Utilities;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class Sales_SalesOrderController : Controller
    {
        // GET: Sales_SalesOrder
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SalesOrder()

        {
            
            ViewBag.route = new SelectList(db.Route, "Route_id", "Route_desc");
            ViewBag.customer = new SelectList(db.tb_Customer, "Name_Customer", "Name_Customer");
            ViewBag.products = new SelectList(db.ITEMS, "Name_Item", "Name_Item");
            return View(db.tb_SalesOrder.OrderByDescending(p => p.item_id).ToList());
        }

        public IList<tb_Customer> Getcustomer(int id)
        {
            return db.tb_Customer.Where(m =>m.Route_Customer == id).ToList();
        }

        public JsonResult GetCustomers(string id)
        {
            List<SelectListItem> customers = new List<SelectListItem>();
            var customerList = this.Getcustomer(Convert.ToInt32(id));
            var customerData = customerList.Select(m => new SelectListItem()
            {
                Text = m.Name_Customer,
                Value = m.Name_Customer.ToString()
            });
            return Json(customerData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Index(FormCollection formdata)
        {
            // Get Employee information to insert into Data Base
            return RedirectToAction("Index", "Sales_SalesOrder");
        }

        public ActionResult AddorEdit(tb_SalesOrder pr)
        {
            var price = db.ITEMS.Where(p => p.Name_Item == pr.Name_Product).First();

            var prox = db.ITEMS.Where(p => p.Name_Item == pr.Name_Product).First();
            prox.STOCK_LEVEL = prox.STOCK_LEVEL - (int)pr.Quantity;
            int? newValue = (int)prox.STOCK_LEVEL;
            db.Entry(prox).State = EntityState.Modified;

            if (newValue <= prox.MIN_MIN_STOCK_LEVEL) // minimum stock level
            {
                Email(prox);
            }



            // Add new

            tb_SalesOrder pro = new tb_SalesOrder();
                pro.Name_Product = pr.Name_Product;
                pro.Code_Product = pr.Name_Product;
                pro.Price = price.COST_PRICE;
                pro.Quantity = pr.Quantity;
                pro.Bill_No = pr.Bill_No;
            // pro.Code_Product = pr.Code_Product;
                pro.Customer = pr.Customer;
            if (pr.Customer == null)
            {
                pro.Customer = pr.SearchButton;
            }

            
            pro.Date = pr.Date;
                pro.Employee = pr.Employee;
                
                db.tb_SalesOrder.Add(pro);
          
              

            db.SaveChanges();

            return RedirectToAction("SalesOrder", "Sales_SalesOrder");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.tb_SalesOrder.Where(p => p.Sales_order_id == id).First();
            db.tb_SalesOrder.Remove(delete);
            var newValue = db.ITEMS.Where(p => p.Name_Item == delete.Name_Product).First();
            newValue.STOCK_LEVEL = newValue.STOCK_LEVEL + (int)delete.Quantity;
            db.SaveChanges();
            
            return RedirectToAction("SalesOrder", "Sales_SalesOrder");
        }

        // new Email Sending method

        public void Email(ITEMS prox)
        {

            string smtpUserName = "creedsadun94@gmail.com";
            string smtpPassword = ""; //enter Email Password
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 25;

            string emailTo = "thamasha@northshore.edu.lk";
            string subject = "Stores Notification";
            string body = "This is an ERP test <br/> " + prox.Name_Item + " sold out";

            Project_MVC5.Models.EmailService newService = new Models.EmailService();

            bool kq = newService.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);


        }

    }
}