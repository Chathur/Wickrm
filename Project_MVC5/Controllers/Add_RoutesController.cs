using PagedList;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class Add_RoutesController : Controller
    {
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();

        // GET: Add_Routes
        public ActionResult Index(Route model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                int RecordsPerPage = 500;

                var results = db.Route
                    .Where(p => p.Name.Equals(model.Name))
                    .OrderBy(p => p.Route_id);

                var pageIndex = model.Page ?? 1;

                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);
            }
            return View(model);
        }

        public ActionResult SearchRoute(Route model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                int RecordsPerPage = 500;

                var results = db.Route
                    .Where(p => p.Name.Equals(model.Name))
                    .OrderBy(p => p.Route_id);

                var pageIndex = model.Page ?? 1;

                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);
            }
            return View(model);
        }

        public ActionResult AddRoute(Route model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                int RecordsPerPage = 500;

                var results = db.Route
                    .Where(p => p.Name.Equals(model.Name))
                    .OrderBy(p => p.Route_id);

                var pageIndex = model.Page ?? 1;

                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);
            }
            return View(model);
        }

        public ActionResult AddorEdit(Route route)
        {
            tb_Employee employee = new tb_Employee();
            if (route.Route_id == 0) // Add new
            {
                Route routenew = new Route();

                routenew.City = route.City;
                routenew.Emoloyee = db.tb_Employee.Where(p => p.Name_Employee == route.EmployeeName).Select(p => p.ID_Employee).First();
                routenew.Name = route.Name;
                routenew.Route_desc = route.Name;

                db.Route.Add(routenew);
            }
            else // edit
            {
                var update = db.Route.Find(route.Route_id);
                update.City = route.City;
                update.Emoloyee = db.tb_Employee.Where(p => p.Name_Employee == route.EmployeeName).Select(p => p.ID_Employee).First();
                update.Name = route.Name;
                update.Route_desc = route.Name;

            }
            db.SaveChanges();

            return RedirectToAction("Index", "Add_Routes");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.Route.Where(p => p.Route_id == id).First();
            db.Route.Remove(delete);
            db.SaveChanges();

            return RedirectToAction("Index", "Add_Routes");
        }
    }
}