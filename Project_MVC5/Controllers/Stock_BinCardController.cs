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
    public class Stock_BinCardController : Controller
    {
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        public ActionResult SearchItem(ITEMS model)
        {
            ViewBag.products = new SelectList(db.ITEMS, "Name_Item", "Name_Item");

            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                int RecordsPerPage = 500;

                var results = db.ITEMS
                    .Where(p => (p.Name_Item.Equals(model.Name_Item) || p.StockCode.Equals(model.StockCode)
                                ))
                     .OrderBy(p => p.StockId);

                var pageIndex = model.Page ?? 1;


                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);
            }
            return View(model);

        }

        public ActionResult AddorEdit(ITEMS sup)
        {
            var update = db.ITEMS.Where(p => p.StockId == sup.StockId).First();

            update.MIN_MIN_STOCK_LEVEL = sup.MIN_MIN_STOCK_LEVEL;
            update.STOCK_LEVEL = sup.STOCK_LEVEL;

            db.Entry(update).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("SearchItem", "Stock_BinCard");
        }
    }
}