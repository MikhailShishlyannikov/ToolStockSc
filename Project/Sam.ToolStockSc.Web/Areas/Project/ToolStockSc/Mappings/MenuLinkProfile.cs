using AutoMapper;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.Rendering_Parameters;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using System.Linq;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Mappings
{
    public class MenuLinkProfile : Profile
    {
        public MenuLinkProfile()
        {
            CreateMap<MenuLinkScModel, MenuLinkViewModel>()
                .ReverseMap();

            CreateMap<MenuLinkRenderingParameter, MenuLinkViewModel>()
                .ForMember(vm => vm.Id, opt => opt.Ignore())
                .ForMember(vm => vm.Icons, opt => opt.MapFrom(rp => rp.Icons.Select(icon => icon.IconTag)));
        }
    }
}