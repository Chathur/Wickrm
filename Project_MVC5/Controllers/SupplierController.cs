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
    public class SupplierController : Controller
    {
        private WICKRAMA_STORESEntities db = new WICKRAMA_STORESEntities();

        // GET: tb_Supplier
        public ActionResult Index()
        {
            return View(db.tb_Supplier.ToList());
        }

        // GET: tb_Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Supplier tb_Supplier = db.tb_Supplier.Find(id);
            if (tb_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(tb_Supplier);
        }

        // GET: tb_Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Supplier,Name_Supplier,Store_Supplier,Address_Supplier,Tel_Supplier")] tb_Supplier tb_Supplier)
        {
            if (ModelState.IsValid)
            {
                db.tb_Supplier.Add(tb_Supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Supplier);
        }

        // GET: tb_Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Supplier tb_Supplier = db.tb_Supplier.Find(id);
            if (tb_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(tb_Supplier);
        }

        // POST: tb_Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Supplier,Name_Supplier,Store_Supplier,Address_Supplier,Tel_Supplier")] tb_Supplier tb_Supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Supplier);
        }

        // GET: tb_Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Supplier tb_Supplier = db.tb_Supplier.Find(id);
            if (tb_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(tb_Supplier);
        }

        // POST: tb_Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Supplier tb_Supplier = db.tb_Supplier.Find(id);
            db.tb_Supplier.Remove(tb_Supplier);
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
