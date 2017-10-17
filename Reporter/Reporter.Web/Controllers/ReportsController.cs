using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Reporter.Data;
using Reporter.Models;
using Reporter.Web.ViewModels;
using AutoMapper.QueryableExtensions;
using Reporter.Web.Infrastructure.Populators;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels.Reports;
using X.PagedList;

namespace Reporter.Web.Controllers
{
    [RoutePrefix("reports")]
    public class ReportsController : BaseController
    {
        private IReportsService reportsService;
        private IDropDownListPopulator populator;

        public ReportsController(IReporterData data, IReportsService service, IDropDownListPopulator populator) 
            : base(data)
        {
            this.reportsService = service;
            this.populator = populator;
        }

        // GET: reports/
        [Route("")]
        public ActionResult All(int? page)
        {
            var reports = reportsService.GetListReportViewModels();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfReports = reports.ToPagedList(pageNumber, 4); // will only contain 25 products max because of the pageSize

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_ReportsList", onePageOfReports)
                : View(onePageOfReports);
        }

        // GET: reports/details/5
        [Route("Details/{id}")]
        public ActionResult Details(Guid id)
        {
            //TODO: to service
            var report = this.Data
                .Reports
                .All()
                .Where(r => r.Id == id)
                .ProjectTo<ReportDetailsViewModel>()
                .FirstOrDefault();

            if (report == null)
            {
                throw new HttpException(404, "Ticket not found.");
            }

            // To filter
            //report.ViewsCount++;
            //var reportDb = Mapper.Map<Report>(report);
            //this.Data.Context.Entry(reportDb).State = EntityState.Modified;
            //this.Data.SaveChanges();

            return View(report);
        }

        // POST: reports/support/id
        [HttpPost]
        public ActionResult Support(Guid id)
        {
            //TODO Improve this
            var report = this.Data.Reports.GetById(id);

            if (report != null)
            {
                report.SupportsCount++;
                this.Data.SaveChanges();
            }

            return Json(report, JsonRequestBehavior.AllowGet);
        }

      
        // GET: reports/create
        [Route("Create")]
        [Authorize]
        public ActionResult Create()
        {
            var createReportViewModel = new CreateReportViewModel()
            {
                Categories = this.populator.GetCategories(),
                Institutions = this.populator.GetInstitutions()
            };

            return View(createReportViewModel);
        }

        // POST: reports/create
        [HttpPost]
        [Route("Create")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReportViewModel report)
        {
            if (!ModelState.IsValid)
            {
                var createReportViewModel = new CreateReportViewModel()
                {
                    Categories = this.populator.GetCategories(),
                    Institutions = this.populator.GetInstitutions()
                };

                return View(createReportViewModel);
            }

            var reportForDb = Mapper.Instance.Map<Report>(report);
            reportForDb.Id = Guid.NewGuid();
            this.UserProfile.Points += 10;
            reportForDb.Reporter = this.UserProfile;

            reportForDb.CreatedOn = DateTime.Now;
            reportForDb.LastUpdatedOn = DateTime.Now;
            reportForDb.Status = ReportStatus.Waiting;

            if (report.FilesForReport != null)
            {
                if (this.reportsService.IsContentTypeValid(report.FilesForReport))
                {
                    var uploadDir = $"~/Content/Uploads/Reports/{reportForDb.Id}/";
                    Directory.CreateDirectory(Server.MapPath(uploadDir));

                    for (var i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileForDb = new Models.File()
                            {
                                Id = Guid.NewGuid(),
                                FileName = file.FileName.Split('.').First(),
                                FileExtension = file.FileName.Split('.').Last(),
                                ContentType = file.ContentType,
                                FileUrl = Path.Combine(uploadDir, file.FileName)
                            };
                            var filePath = Path.Combine(Server.MapPath(uploadDir), file.FileName);
                            reportForDb.Files.Add(fileForDb);
                            file.SaveAs(filePath);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("FilesForReport", "Not allowed file content!");
                }
            }

            this.Data.Reports.Add(reportForDb);
            this.Data.SaveChanges();

            //Redirect to current report?
            return RedirectToAction("Details", new {id = reportForDb.Id});
        }

        // GET: reports/download/{id}
        [Route("download")]
        public FileResult Download(Guid id)
        {
            var file = this.Data.Files.GetById(id);

            return File(file.FileUrl, file.ContentType, file.FileName + "." + file.FileExtension);
        }
    }
}
