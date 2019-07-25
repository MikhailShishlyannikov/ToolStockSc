using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.Rendering_Parameters;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(INavLinkService))]
    public class NavLinkService : INavLinkService
    {
        private readonly IMapper _mapper;

        public NavLinkService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public NavLinkViewModel Get(IMvcContext mvcContext)
        {
            var vm = _mapper.Map<NavLinkViewModel>(mvcContext.GetDataSourceItem<NavLinkScModel>());
            _mapper.Map(mvcContext.GetRenderingParameters<NavLinkRenderingParameter>(), vm);

            return vm;
        }
    }
}