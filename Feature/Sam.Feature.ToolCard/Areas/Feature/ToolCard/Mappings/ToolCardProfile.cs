using AutoMapper;
using Sam.Feature.ToolCard.Areas.Feature.ToolCard.Models.ScModels;
using Sam.Feature.ToolCard.Areas.Feature.ToolCard.Models.ViewModels;

namespace Sam.Feature.ToolCard.Areas.Feature.ToolCard.Mappings
{
    public class ToolCardProfile : Profile
    {
        public ToolCardProfile()
        {
            CreateMap<ToolCardScModel, ToolCardViewModel>()
                .ReverseMap();
        }
    }
}