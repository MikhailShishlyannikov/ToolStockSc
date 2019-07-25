using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.Rendering_Parameters;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IMenuLinkService))]
    public class MenuLinkService : IMenuLinkService
    {
        private readonly IMapper _mapper;

        public MenuLinkService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public MenuLinkViewModel Get(IMvcContext mvcContext)
        {
            var vm = _mapper.Map<MenuLinkViewModel>(mvcContext.GetDataSourceItem<MenuLinkScModel>());
            _mapper.Map(mvcContext.GetRenderingParameters<MenuLinkRenderingParameter>(), vm);

            return vm;
        }
    }
}