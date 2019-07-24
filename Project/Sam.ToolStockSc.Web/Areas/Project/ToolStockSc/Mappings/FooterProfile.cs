using AutoMapper;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Mappings
{
    public class FooterProfile : Profile
    {
        public FooterProfile()
        {
            CreateMap<FooterScModel, FooterViewModel>()
                .ReverseMap();
        }
    }
}