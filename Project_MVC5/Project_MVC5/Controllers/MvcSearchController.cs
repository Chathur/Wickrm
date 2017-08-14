using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace Project_MVC5.Controllers
{
    public class MvcSearchController : Controller
    {
        // GET: MvcSearch
        const int RecordsperPage = 500;

        //public ActionResult Index(tb_SalesOrder model)
       // {
          //  if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
           // {
           //     var entities = new Demo_onlineEntities();
           //     var results = entities.tb_SalesOrder.Where(p => (p.Bill_No == model.Bill_No)).OrderBy(p=>p.ID_Product);
           //     var pageIndex = model.Page ?? 1;
            //    model.SearchResults = results.ToPagedList(pageIndex, RecordsperPage);
           // }
          //  return View(model);
       // }
    }
}