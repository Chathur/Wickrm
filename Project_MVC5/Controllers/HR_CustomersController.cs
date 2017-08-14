using PagedList;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class HR_CustomersController : Controller
    {
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        // GET: HR_Customers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchCustomer(tb_Customer model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                int RecordsPerPage = 500;

                var results = db.tb_Customer
                    .Where(p => (p.Name_Customer.Equals(model.Name_Customer)
                                ))
                     .OrderBy(p => p.ID_Customer);

                var pageIndex = model.Page ?? 1;


                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);
            }
            return View(model);
        }

    }
}