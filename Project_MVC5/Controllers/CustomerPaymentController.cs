using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class CustomerPaymentController : Controller
    {
        // GET: CustomerPayment
        [Route("Payment")]
        public ActionResult CustomerPayment()
        {
            return View();
        }

        // GET: CustomerPayment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerPayment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerPayment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerPayment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerPayment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerPayment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerPayment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}