using AutoMapper;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.Rendering_Parameters;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Mappings
{
    public class NavLinkProfile : Profile
    {
        public NavLinkProfile()
        {
            CreateMap<NavLinkScModel, NavLinkViewModel>()
                .ReverseMap();

            CreateMap<NavLinkRenderingParameter, NavLinkViewModel>()
                .ForMember(vm => vm.Id, opt => opt.Ignore())
                .ForMember(vm => vm.Icon, opt => opt.MapFrom(rp => rp.Icon.IconTag));
        }
    }
}