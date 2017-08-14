using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class PurchaseGRNController : Controller
    {
        Demo_onlineEntities db = new Demo_onlineEntities();
        // GET: PurchaseGRN
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewPurchaseGRN()
        {
            return View(db.tb_Product.OrderByDescending(p => p.ID_Product).ToList());
        }
        public ActionResult AddorEdit(tb_Product pr)
        {
            
            if (pr.ID_Product == 0) // Add new
            {
                tb_Product pro = new tb_Product();
                pro.Name_Product = pr.Name_Product;
                pro.Price = pr.Price;
                pro.Quantity = pr.Quantity;
                pro.Description = pr.Description;
                db.tb_Product.Add(pro);
                
                
            }
            else // edit
            {
                var update = db.tb_Product.Find(pr.ID_Product);
                update.Name_Product = pr.Name_Product;
                update.Price = pr.Price;
                update.Quantity = pr.Quantity;
                update.Description = pr.Description;
                
            }
            db.SaveChanges();

            return RedirectToAction("ViewPurchaseGRN", "PurchaseGRN");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.tb_Product.Where(p => p.ID_Product == id).First();
            db.tb_Product.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("ViewPurchaseGRN", "PurchaseGRN");
        }
    }
}