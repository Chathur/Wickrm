using PagedList;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{

    public class HR_EmployeeController : Controller
    {
        WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();
        // GET: HR_Employee
        public ActionResult Employee()
        {
            return View();
        }
        public ActionResult SearchEmployee(tb_Employee model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                int RecordsPerPage = 500;

                var results = db.tb_Employee
                    .Where(p => (p.Name_Employee.Equals(model.Name_Employee)
                                ))
                     .OrderBy(p => p.ID_Employee);

                var pageIndex = model.Page ?? 1;


                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);
            }
            return View(model);
        }

        public ActionResult AddEmployee(tb_Employee model)
        {

            int RecordsPerPage = 5;
            var results = db.tb_Employee.OrderByDescending(p => p.ID_Employee);
            var pageIndex = model.Page ?? 1;
            model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);

            return View(model);

        }
        public ActionResult AddorEdit(tb_Employee sup)
        {

            if (sup.ID_Employee == 0) // Add new
            {
                tb_Employee pro = new tb_Employee();
                pro.Name_Employee = sup.Name_Employee;
                pro.Address_Employee = sup.Address_Employee;
                pro.Job_tile = sup.Job_tile;
                pro.Tel_Employee = sup.Tel_Employee;
                pro.email = sup.email;
                pro.Salary = sup.Salary;
                pro.Joining_Date = sup.Joining_Date;
                pro.Still_working = sup.Still_working;

                db.tb_Employee.Add(pro);


            }
            else // edit
            {
                var update = db.tb_Employee.Find(sup.ID_Employee);
                update.Name_Employee = sup.Name_Employee;
                update.Address_Employee = sup.Address_Employee;
                update.Job_tile = sup.Job_tile;
                update.Tel_Employee = sup.Tel_Employee;
                update.email = sup.email;
                update.Salary = sup.Salary;
                update.Joining_Date = sup.Joining_Date;
                update.Still_working = sup.Still_working;

            }
            db.SaveChanges();

            return RedirectToAction("AddEmployee", "HR_Employee");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.tb_Employee.Where(p => p.ID_Employee == id).First();
            db.tb_Employee.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("AddEmployee", "HR_Employee");
        }
    }
}