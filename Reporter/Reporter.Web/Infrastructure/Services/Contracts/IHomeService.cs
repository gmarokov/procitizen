using System.Collections.Generic;
using Reporter.Web.ViewModels;
using Reporter.Web.ViewModels.Home;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.Infrastructure.Services.Contracts
{
    public interface IHomeService
    {
        IndexViewModel GetIndexViewModel();
    }
}
