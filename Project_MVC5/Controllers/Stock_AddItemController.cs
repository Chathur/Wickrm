using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class Stock_AddItemController : Controller
    {
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        // GET: Stock_AddItem
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Stock_AddItem()
        {
            return View(db.ITEMS.OrderByDescending(p => p.StockId).ToList());
        }
        public ActionResult AddorEdit(ITEMS pr)
        {

            if (pr.StockId == 0) // Add new
            {
                ITEMS pro = new ITEMS();
                pro.Name_Item = pr.Name_Item;
                pro.StockCode = pr.StockCode;
                pro.Type = pr.Type;
                pro.COST_PRICE = pr.COST_PRICE;
                pro.Retail_Margin = pr.Retail_Margin;
                pro.Trade_Margin = pr.Trade_Margin;
                pro.Vendor_Name = pr.Vendor_Name;
                pro.Add_Quantity = pr.Add_Quantity;
                pro.STOCK_LEVEL =(pro.STOCK_LEVEL + (int)pr.Add_Quantity);
                
                // use for GRN pro.STOCK_LEVEL = (pr.STOCK_LEVEL + (int)pr.Add_Quantity);
                db.ITEMS.Add(pro);


            }
            else // edit
            {
                var update = db.ITEMS.Find(pr.StockId);
                update.Name_Item = pr.Name_Item;
                update.COST_PRICE = pr.COST_PRICE;
               // USE FOR GRN  update.STOCK_LEVEL = (pr.STOCK_LEVEL + (int)pr.Add_Quantity);


            }
            db.SaveChanges();

            return RedirectToAction("Stock_AddItem", "Stock_AddItem");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.ITEMS.Where(p => p.StockId == id).First();
            db.ITEMS.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Stock_AddItem", "Stock_AddItem");
        }
    }
}