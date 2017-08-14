using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_MVC5.Models;

namespace Project_MVC5.Controllers
{
    public class tb_SalesController : Controller
    {
        private Demo_onlineEntities db = new Demo_onlineEntities();

        // GET: tb_Sales
        public ActionResult Index()
        {
            return View(db.tb_Sales.ToList());
        }

        // GET: tb_Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Sales tb_Sales = db.tb_Sales.Find(id);
            if (tb_Sales == null)
            {
                return HttpNotFound();
            }
            return View(tb_Sales);
        }

        // GET: tb_Sales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Product,Code_Product,Name_Product,Price,Quantity,Total,Date,Employee,Bill_No,Customer")] tb_Sales tb_Sales)
        {
            if (ModelState.IsValid)
            {
                db.tb_Sales.Add(tb_Sales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Sales);
        }

        // GET: tb_Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Sales tb_Sales = db.tb_Sales.Find(id);
            if (tb_Sales == null)
            {
                return HttpNotFound();
            }
            return View(tb_Sales);
        }

        // POST: tb_Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Product,Code_Product,Name_Product,Price,Quantity,Total,Date,Employee,Bill_No,Customer")] tb_Sales tb_Sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Sales);
        }

        // GET: tb_Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Sales tb_Sales = db.tb_Sales.Find(id);
            if (tb_Sales == null)
            {
                return HttpNotFound();
            }
            return View(tb_Sales);
        }

        // POST: tb_Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Sales tb_Sales = db.tb_Sales.Find(id);
            db.tb_Sales.Remove(tb_Sales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
