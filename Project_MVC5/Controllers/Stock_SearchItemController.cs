using PagedList;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class Stock_SearchItemController : Controller
    {
        // GET: Stock_SearchItem
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        public ActionResult SearchItem(ITEMS model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                int RecordsPerPage = 500;

                var results = db.ITEMS
                    .Where(p => (p.Name_Item.Equals(model.Name_Item)
                                ))
                     .OrderBy(p => p.StockId);

                var pageIndex = model.Page ?? 1;


                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);
            }
            return View(model);
           
        }
        public ActionResult AddorEdit(ITEMS sup)
        {
            var item = db.ITEMS.Where(p => p.StockId == sup.StockId).First();

            
                var update = db.ITEMS.Where(p => p.StockId == sup.StockId).First();
            update.Name_Item = sup.Name_Item;
                update.StockCode = sup.StockCode;
                update.Type = sup.Type;
                update.MIN_MIN_STOCK_LEVEL = sup.MIN_MIN_STOCK_LEVEL;
                update.COST_PRICE = sup.COST_PRICE;
                update.Retail_Margin = sup.Retail_Margin;
                update.Trade_Margin = sup.Trade_Margin;

                update.STOCK_LEVEL = item.STOCK_LEVEL;
                update.Vendor_Name = item.Vendor_Name;

                db.Entry(update).State = EntityState.Modified;

            
            db.SaveChanges();

            return RedirectToAction("SearchItem", "Stock_SearchItem");
        }
        public ActionResult Delete(int id)
        {
            var delete = db.ITEMS.Where(p => p.StockId == id).First();
            db.ITEMS.Remove(delete);

            db.SaveChanges();

            return RedirectToAction("SearchItem", "Stock_SearchItem");
        }
    }
}