using System.Web.Mvc;
using Reporter.Data;
using System;
using System.Linq;
using System.Web.Routing;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Reporter.Models;

namespace Reporter.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IReporterData data)
        {
            this.Data = data;
        }

        protected IReporterData Data { get; private set; }

        protected AppUser UserProfile { get; private set; }

        //protected IMapper Mapper { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile =
                this.Data.Users.All()
                    .Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name)
                    .FirstOrDefault();
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}