using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class PurchaseGRNController : Controller
    {
        static string name = null;
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        // GET: PurchaseGRN
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewPurchaseGRN()
        {
            ITEMS order = new ITEMS();

            ViewBag.products = new SelectList(db.ITEMS, "Name_Item", "Name_Item");
            ViewBag.suppliers = new SelectList(db.tb_Supplier, "Name_Supplier", "Name_Supplier");
            return View(db.ITEMS.Where(p=>p.Name_Item==name).OrderByDescending(p => p.StockId).ToList());
        }
        public ActionResult AddorEdit(ITEMS sup)
        {

         // var item = db.ITEMS.Where(p => p.StockId == sup.StockId).First();

            var update = db.ITEMS.Where(p => p.Name_Item == sup.Name_Item).First();
            name = sup.Name_Item;
            update.Add_Quantity = sup.Add_Quantity;
            update.Free_Items = sup.Free_Items;
            update.COST_PRICE = sup.COST_PRICE;
            update.Retail_Margin = sup.Retail_Margin;
            update.Discount = sup.Discount;

            update.STOCK_LEVEL =  update.STOCK_LEVEL+ (int)sup.Add_Quantity + (int)sup.Free_Items;

            db.Entry(update).State = EntityState.Modified;


            db.SaveChanges();
            return RedirectToAction("ViewPurchaseGRN", "PurchaseGRN");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.ITEMS.Where(p => p.StockId == id).First();
            db.ITEMS.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("ViewPurchaseGRN", "PurchaseGRN");
        }
    }
}