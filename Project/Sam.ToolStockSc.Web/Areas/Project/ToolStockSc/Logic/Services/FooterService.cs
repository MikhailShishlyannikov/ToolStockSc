using AutoMapper;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IFooterService))]
    public class FooterService : IFooterService
    {
        private readonly IMapper _mapper;

        public FooterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public FooterViewModel Get(IMvcContext mvcContexts)
        {
            var scModel = mvcContexts.GetDataSourceItem<FooterScModel>();

            return _mapper.Map<FooterViewModel>(scModel);
        }
    }
}