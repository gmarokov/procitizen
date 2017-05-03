using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Reporter.Data;
using Reporter.Web.Infrastructure.Caching;

namespace Reporter.Web.Infrastructure.Populators
{
    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IReporterData data;
        private ICacheService cache;

        public DropDownListPopulator(IReporterData data, ICacheService cache)
        {
            this.data = data;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var categories = this.cache.Get<IEnumerable<SelectListItem>>("categories", () =>
            {
                return this.data.Categories
                    .All()
                    .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });
            });

            return categories;
        }

        public IEnumerable<SelectListItem> GetInstitutions()
        {
            var institutions = this.cache.Get<IEnumerable<SelectListItem>>("institutions", () =>
            {
                return this.data.Institutions
                    .All()
                    .Select(i => new SelectListItem()
                    {
                        Value = i.Id.ToString(),
                        Text = i.Name
                    });
            });

            return institutions;
        }
    }
}