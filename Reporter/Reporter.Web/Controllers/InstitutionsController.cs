using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Reporter.Data;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels.Institutions;
using Reporter.Web.ViewModels.Reports;
using X.PagedList;

namespace Reporter.Web.Controllers
{
    [RoutePrefix("institutions")]
    public class InstitutionsController : BaseController
    {
        private IInstitutionsService _institutionsService;

        public InstitutionsController(IReporterData data, IInstitutionsService service)
            : base(data)
        {
            this._institutionsService = service;
        }

        // GET: institutions
        [Route("all")]
        public ActionResult All(int? page)
        {
            var institutions = _institutionsService.GetListInstitutionViewModels();

            var pageNumber = page ?? 1;
            var onePageOfInstitutions = institutions.ToPagedList(pageNumber, 4);

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_InstitutionsList", onePageOfInstitutions)
                : View(onePageOfInstitutions);
        }

        // GET: institutions/details/5
        [Route("details/{id}")]
        public ActionResult Details(int? id)
        {
            var institution = this.Data
                .Institutions
                .All()
                .Where(i => i.Id == id)
                .ProjectTo<InstitutionDetailsViewModel>()
                .FirstOrDefault();

            if (institution == null)
            {
                throw new HttpException(404, "Institution not found.");
            }

            return View(institution);
        }
    }
}