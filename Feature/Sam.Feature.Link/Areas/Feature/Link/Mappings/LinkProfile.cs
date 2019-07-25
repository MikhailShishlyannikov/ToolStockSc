using AutoMapper;
using Sam.Feature.Link.Areas.Feature.Link.Models.ScModels;
using Sam.Feature.Link.Areas.Feature.Link.Models.ViewModels;

namespace Sam.Feature.Link.Areas.Feature.Link.Mappings
{
    public class LinkProfile : Profile
    {
        public LinkProfile()
        {
            CreateMap<LinkScModel, LinkViewModel>()
                .ReverseMap();
        }
    }
}