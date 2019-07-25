using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(IMenuSectionService))]
    public class MenuSectionService : IMenuSectionService
    {
        private readonly IMapper _mapper;

        public MenuSectionService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public MenuSectionViewModel Get(IMvcContext mvcContext)
        {
            return _mapper.Map<MenuSectionViewModel>(mvcContext.GetDataSourceItem<MenuSectionScModel>());
        }
    }
}