using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vcardsh.web.Controllers
{
    public class DetallesController : Controller
    {
        // GET: Detalles
        public ActionResult Index()
        {
            return View();
        }

        // GET: Detalles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Detalles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Detalles/Create
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

        // GET: Detalles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Detalles/Edit/5
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

        // GET: Detalles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Detalles/Delete/5
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
