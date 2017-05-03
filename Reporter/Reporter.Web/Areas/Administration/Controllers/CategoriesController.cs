using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reporter.Data;

namespace Reporter.Web.Areas.Administration.Controllers
{
    public class CategoriesController : AdminController
    {
        // GET: Administration/Categories
        public CategoriesController(IReporterData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Categories/Create
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

        // GET: Administration/Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Categories/Edit/5
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

        // GET: Administration/Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Categories/Delete/5
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
