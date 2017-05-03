using System.Web.Mvc;
using Reporter.Data;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels.Institutions;
using Reporter.Web.ViewModels.Statistics;

namespace Reporter.Web.Controllers
{
    [RoutePrefix("statistics")]
    public class StatisticsController : BaseController
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IReporterData data, IStatisticsService statisticsService) 
            : base(data)
        {
            this._statisticsService = statisticsService;
        }

        // GET: statistics/index
        [Route("Index")]
        public ActionResult Index()
        {
            return View(this._statisticsService.GetIndexViewModel());
        }
    }
}