using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Web.ViewModels.Institutions;
using Reporter.Web.ViewModels.Reporters;

namespace Reporter.Web.Infrastructure.Services.Contracts
{
    public interface IInstitutionsService
    {
        IList<ListInstitutionViewModel> GetListInstitutionViewModels();
    }
}
