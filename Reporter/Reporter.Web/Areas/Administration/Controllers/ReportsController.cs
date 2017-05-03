using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Ajax.Utilities;
using Reporter.Data;
using Reporter.Models;
using Reporter.Web.Areas.Administration.ViewModels.Reports;
using Reporter.Web.Controllers;
using Reporter.Web.Infrastructure.Populators;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels;
using Reporter.Web.ViewModels.Reports;
using X.PagedList;

namespace Reporter.Web.Areas.Administration.Controllers
{
    [RoutePrefix("reports")]
    public class ReportsController : AdminController
    {
        private readonly IReportsService _reportsService;
        private IDropDownListPopulator _populator;

        public ReportsController(IReporterData data, IReportsService reportsService, IDropDownListPopulator populator) 
            : base(data)
        {
            this._reportsService = reportsService;
            this._populator = populator;
        }

        // GET: Administration/Reports
        [HttpGet]
        //[Route("")]
        public ActionResult All(int? page)
        {
            var reports = _reportsService.GetAdminListReportViewModels();
            var pageNumber = page ?? 1; 
            var onePageOfReports = reports.ToPagedList(pageNumber, 4); 

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_ReportsTBodyAdmin", onePageOfReports)
                : View(onePageOfReports);
        }

        // GET: Administration/Reports/Details/5
        public JsonResult Details(Guid? id)
        {
            var report = this.Data
                .Reports
                .All()
                .Where(r => r.Id == id)
                .ProjectTo<EditReportViewModel>()
                .FirstOrDefault();

            if (report == null)
            {
                throw new HttpException(404, "Report not found.");
            }

            report.Categories = this._populator.GetCategories();
            //report.Institutions = this._populator.GetInstitutions();

            var json = Json(report, JsonRequestBehavior.AllowGet);
            return json;
        }

        // POST: Administration/Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Update(EditReportViewModel report)
        {
            if (ModelState.IsValid)
            {
                var dbReport = this.Data.Reports.GetById(report.Id);
                dbReport.ReporterId = report.ReporterId;
                dbReport.Title = report.Title;
                dbReport.CategoryId = report.SelectedCategoryId;
                dbReport.Description = report.Description;
                dbReport.Status = ReportStatus.Reported;
                dbReport.LastUpdatedOn = DateTime.Now;
                this.Data.Context.Entry(dbReport).State = EntityState.Modified;
                this.Data.SaveChanges();
            }

            return Json(report, JsonRequestBehavior.AllowGet);
        }


        // POST: Administration/Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var report = this.Data.Reports.GetById(id);

            if (report != null)
            {
                this.Data.Reports.Delete(id);
                this.Data.SaveChanges();
            }

            return Json(report, JsonRequestBehavior.AllowGet);
        }

    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        db.Dispose();
    //    }
    //    base.Dispose(disposing);
    //}
}
}
