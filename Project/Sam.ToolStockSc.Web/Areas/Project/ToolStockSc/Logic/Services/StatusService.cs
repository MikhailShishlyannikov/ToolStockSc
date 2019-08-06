using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IStatusService))]
    public class StatusService : IStatusService
    {
        private readonly SitecoreService _sitecoreService = new SitecoreService(SitecoreConstants.MasterDatabase.Master);

        public IEnumerable<StatusScModel> GetAll()
        {
            return SitecoreConstants.ParentItems.Statuses.Children.Select(x =>
                _sitecoreService.GetItem<StatusScModel>(x));
        }

        public StatusScModel Get(string name)
        {
            return GetAll().FirstOrDefault(x => x.Name == name);
        }
    }
}