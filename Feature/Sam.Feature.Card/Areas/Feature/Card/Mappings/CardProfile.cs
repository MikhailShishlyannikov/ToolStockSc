using AutoMapper;
using Sam.Feature.Card.Areas.Feature.Card.Models.ScModels;
using Sam.Feature.Card.Areas.Feature.Card.Models.ViewModels;

namespace Sam.Feature.Card.Areas.Feature.Card.Mappings
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardScModel, CardViewModel>()
                .ReverseMap();
        }
    }
}