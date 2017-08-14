using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_MVC5.Models;
using System.Data.Entity;
using System.Data;

namespace Project_MVC5.Controllers
{
    public class Sales_DirectSalesController : Controller
    {
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();

        // GET: Sales_DirectSales
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowCart()
        {
            ViewBag.route = new SelectList(db.Route, "Route_id", "Route_desc");
            ViewBag.customer = new SelectList(db.tb_Customer, "Name_Customer", "Name_Customer");
            ViewBag.products = new SelectList(db.ITEMS, "Name_Item", "Name_Item");
            return View(db.tb_Sales.OrderByDescending(p => p.item_id).ToList());
        }
        public ActionResult AddorEdit(tb_Sales ca)
        {

            if (ca.ID == 0) // Add new
            {
                var price = db.ITEMS.Where(p => p.Name_Item == ca.Name_Product).First();

                var prox = db.ITEMS.Where(p => p.Name_Item == ca.Name_Product).First();
                prox.STOCK_LEVEL = prox.STOCK_LEVEL - (int)ca.Quantity;
                int? newValue = (int)prox.STOCK_LEVEL;
                db.Entry(prox).State = EntityState.Modified;

                if (newValue <= prox.MIN_MIN_STOCK_LEVEL) // minimum stock level
                {
                    Email(prox);
                }
                // Add new

                tb_Sales pro = new tb_Sales();
                pro.Name_Product = ca.Name_Product;
                pro.Code_Product = ca.Name_Product;
                pro.Price = price.COST_PRICE;
                pro.Quantity = ca.Quantity;
                pro.Bill_No = ca.Bill_No;
                // pro.Code_Product = pr.Code_Product;
                pro.Customer = ca.Customer;
                if (ca.Customer == null)
                {
                    pro.Customer = ca.SearchButton;
                }
                pro.Date = ca.Date;
                pro.Employee = ca.Employee;
               

                db.tb_Sales.Add(pro);
            }

            db.SaveChanges();
            return RedirectToAction("ShowCart", "Sales_DirectSales");

        }
        public ActionResult Delete(int id)
        {
            var delete = db.tb_Sales.Where(p => p.ID == id).First();
            //newValue to add the items back to stores
            var newValue = db.ITEMS.Where(p => p.Name_Item == delete.Name_Product).First();
            newValue.STOCK_LEVEL = newValue.STOCK_LEVEL + (int)delete.Quantity;

            db.tb_Sales.Remove(delete);
            
            db.SaveChanges();
            return RedirectToAction("ShowCart", "Sales_DirectSales");
        }

        public ActionResult Clear()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [tb_Cart]");
            
            db.SaveChanges();
            return RedirectToAction("ShowCart", "Sales_DirectSales");
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
                string body = "This is an ERP test <br/> "+prox.Name_Item+" sold out";

                Project_MVC5.Models.EmailService newService = new Models.EmailService();

                bool kq = newService.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);

            
        }
    }
}