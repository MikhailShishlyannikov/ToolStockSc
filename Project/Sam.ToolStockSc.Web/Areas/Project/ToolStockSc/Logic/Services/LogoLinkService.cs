using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(ILogoLinkService))]
    public class LogoLinkService : ILogoLinkService
    {
        private readonly IMapper _mapper;
        public LogoLinkService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public LogoLinkViewModel Get(IMvcContext mvcContext)
        {
            return _mapper.Map<LogoLinkViewModel>(mvcContext.GetDataSourceItem<LogoLinkScModel>());
        }
    }
}