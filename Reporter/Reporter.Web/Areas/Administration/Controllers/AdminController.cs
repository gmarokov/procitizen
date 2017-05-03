using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reporter.Common;
using Reporter.Data;
using Reporter.Web.Controllers;

namespace Reporter.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdminRole +", "+ GlobalConstants.ModeratorRole)]
    public abstract class AdminController : BaseController
    {
        protected AdminController(IReporterData data) 
            : base(data)
        {
            
        }
    }
}