using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Reporter.Data;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels;

namespace Reporter.Web.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : BaseController
    {
        private IHomeService homeService;

        public HomeController(IReporterData data, IHomeService homeService) 
            : base(data)
        {
            this.homeService = homeService;
            //this.Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        //[Route("")]
        //[OutputCache(Duration = 60 * 60)]
        public ActionResult Index()
        {
            return View(this.homeService.GetIndexViewModel(6));
        }

        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Route("error")]
        //public ActionResult Error()
        //{
        //    return View();
        //}
    }
}