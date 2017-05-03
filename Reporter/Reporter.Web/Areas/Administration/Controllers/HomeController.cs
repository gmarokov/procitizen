using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reporter.Data;

namespace Reporter.Web.Areas.Administration.Controllers
{
    [RouteArea("Administration")]
    [RoutePrefix("home")]
    public class HomeController : AdminController
    {
        public HomeController(IReporterData data) : base(data)
        {
        }

        // GET: Administration/Home
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}