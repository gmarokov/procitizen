using System.Collections.Generic;
using Reporter.Web.ViewModels.Reporters;

namespace Reporter.Web.Infrastructure.Services.Contracts
{
    public interface IReportersService
    {
        IList<ListReporterViewModel> GetListReporterViewModels();
    }
}
