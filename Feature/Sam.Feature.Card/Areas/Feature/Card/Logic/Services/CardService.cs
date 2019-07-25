using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Card.Areas.Feature.Card.Logic.Interfaces;
using Sam.Feature.Card.Areas.Feature.Card.Models.ScModels;
using Sam.Feature.Card.Areas.Feature.Card.Models.ViewModels;
using Sam.Foundation.DependencyInjection;

namespace Sam.Feature.Card.Areas.Feature.Card.Logic.Services
{
    [Service(typeof(ICardService))]
    public class CardService : ICardService
    {
        private readonly IMapper _mapper;

        public CardService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CardViewModel Get(IMvcContext mvcContext)
        {
            return _mapper.Map<CardViewModel>(mvcContext.GetDataSourceItem<CardScModel>());
        }
    }
}