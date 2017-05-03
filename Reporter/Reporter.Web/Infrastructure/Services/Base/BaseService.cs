using AutoMapper;
using Reporter.Data;

namespace Reporter.Web.Infrastructure.Services.Base
{
    public abstract class BaseService
    {
        protected IReporterData Data { get; private set; }

        public BaseService(IReporterData data)
        {
            this.Data = data;
        }
    }
}