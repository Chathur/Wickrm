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
        Demo_onlineEntities db = new Demo_onlineEntities();

        // GET: Sales_DirectSales
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowCart()
        {
            return View(db.tb_Cart.ToList());
        }
        public ActionResult AddorEdit(tb_Cart ca)
        {

            if (ca.ID_Product == 0) // Add new
            {
               tb_Cart cart = new tb_Cart();
               //prox to reduce the quantity from stores
               var prox = db.tb_Product.Where(p => p.Name_Product == ca.Name_Product).First();
               prox.Quantity = (prox.Quantity - ca.Quantity);
               int ? newValue = prox.Quantity;
               db.Entry(prox).State = EntityState.Modified;

                if (newValue <= 5)
                {
                    Email(prox);
                }

               cart.Name_Product = ca.Name_Product;
               cart.Price = ca.Price;
               cart.Quantity = ca.Quantity;

               db.tb_Cart.Add(cart);
               
            }
            else
            {
                var update = db.tb_Cart.Find(ca.ID_Product);
                
                update.Name_Product = ca.Name_Product;
                update.Price = ca.Price;
                update.Quantity = ca.Quantity;
                update.Total = ca.Total;
            }

            db.SaveChanges();
            return RedirectToAction("ShowCart", "Sales_DirectSales");

        }
        public ActionResult Delete(int id)
        {
            var delete = db.tb_Cart.Where(p => p.ID_Product == id).First();
            //newValue to add the items back to stores
            var newValue = db.tb_Product.Where(p => p.Name_Product == delete.Name_Product).First();
            newValue.Quantity = (newValue.Quantity + delete.Quantity);

            db.tb_Cart.Remove(delete);
            
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

        public void Email(tb_Product prox)
        {

                string smtpUserName = "creedsadun94@gmail.com";
                string smtpPassword = ""; //enter Email Password
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 25;
                
                string emailTo = "thamasha@northshore.edu.lk";
                string subject = "Stores Notification";
                string body = "This is an ERP test <br/> "+prox.Name_Product+" sold out";

                Project_MVC5.Models.EmailService newService = new Models.EmailService();

                bool kq = newService.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);

            
        }
    }
}