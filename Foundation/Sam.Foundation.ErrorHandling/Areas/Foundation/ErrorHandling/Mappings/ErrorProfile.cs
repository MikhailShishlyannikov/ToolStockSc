using AutoMapper;
using Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Models.ScModels;
using Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Models.ViewModels;

namespace Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Mappings
{
    public class ErrorProfile : Profile
    {
        public ErrorProfile()
        {
            CreateMap<ErrorScModel, ErrorViewModel>()
                .ReverseMap();
        }
    }
}