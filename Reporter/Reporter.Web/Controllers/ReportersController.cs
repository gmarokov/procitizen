using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Reporter.Data;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels.Reporters;
using X.PagedList;

namespace Reporter.Web.Controllers
{
    [RoutePrefix("reporters")]
    public class ReportersController : BaseController
    {
        private IReportersService reportersService;

        public ReportersController(IReporterData data, IReportersService service) 
            : base(data)
        {
            this.reportersService = service;
        }

        // GET: Reporters
        [Route("all")]
        public ActionResult All(int? page)
        {
            var reporters = this.reportersService.GetListReporterViewModels();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfReporters = reporters.ToPagedList(pageNumber, 4); // will only contain 25 products max because of the pageSize

            //ViewBag.OnePageOfReports = onePageOfReports;

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_ReportersList", onePageOfReporters)
                : View(onePageOfReporters);
        }

        // GET: Reporters/Details/5
        [Route("details/{id}")]
        public ActionResult Details(string id)
        {
            //TODO: to service
            var reporter = this.Data
                .Users
                .All()
                .Where(u => u.Id.Equals(id))
                .ProjectTo<ReporterDetailsViewModel>()
                .FirstOrDefault();

            if (reporter == null)
            {
                throw new HttpException(404, "Reporter not found.");
            }

            return View(reporter);
        }

        // GET: Reporters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reporters/Create
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

        // GET: Reporters/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reporters/Edit/5
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

        // GET: Reporters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reporters/Delete/5
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
