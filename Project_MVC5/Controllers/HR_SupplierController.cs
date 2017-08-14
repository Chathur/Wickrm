using PagedList;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class HR_SupplierController : Controller
       
    {
        // GET: HR_Supplier
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        public ActionResult Supplier()
        {
            return View();
        }
        
        public ActionResult SearchSupplier(tb_Supplier model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                int RecordsPerPage = 500;

                var results = db.tb_Supplier
                    .Where(p => (p.Name_Supplier.Equals(model.Name_Supplier)
                                ))
                     .OrderBy(p => p.ID_Supplier);

                var pageIndex = model.Page ?? 1;


                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);
            }
            return View(model);
        }

        public ActionResult AddSupplier(tb_Supplier model)
        {

            int RecordsPerPage = 5;
            var results = db.tb_Supplier.OrderByDescending(p => p.ID_Supplier);
            var pageIndex = model.Page ?? 1;
            model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);

            return View(model);

        }
        public ActionResult AddorEdit(tb_Supplier sup)
        {

            if (sup.ID_Supplier == 0) // Add new
            {
                tb_Supplier pro = new tb_Supplier();
                pro.Name_Supplier = sup.Name_Supplier;
                pro.Address_Supplier = sup.Address_Supplier;
                pro.Store_Supplier = sup.Store_Supplier;
                pro.Tel_Supplier = sup.Tel_Supplier;
                db.tb_Supplier.Add(pro);


            }
            else // edit
            {
                var update = db.tb_Supplier.Find(sup.ID_Supplier);
                update.Name_Supplier = sup.Name_Supplier;
                update.Address_Supplier = sup.Address_Supplier;
                update.Store_Supplier = sup.Store_Supplier;
                update.Tel_Supplier = sup.Tel_Supplier;

            }
            db.SaveChanges();

            return RedirectToAction("AddSupplier", "HR_Supplier");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.tb_Supplier.Where(p => p.ID_Supplier == id).First();
            db.tb_Supplier.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("AddSupplier", "HR_Supplier");
        }
    }
}