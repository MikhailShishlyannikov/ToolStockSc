using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.ToolCard.Areas.Feature.ToolCard.Logic.Interfaces;
using Sam.Feature.ToolCard.Areas.Feature.ToolCard.Models.ScModels;
using Sam.Feature.ToolCard.Areas.Feature.ToolCard.Models.ViewModels;
using Sam.Foundation.DependencyInjection;

namespace Sam.Feature.ToolCard.Areas.Feature.ToolCard.Logic.Services
{
    [Service(typeof(IToolCardService))]
    public class ToolCardService : IToolCardService
    {
        private readonly IMapper _mapper;

        public ToolCardService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ToolCardViewModel GetViewModel(IMvcContext mvcContext)
        {
            return _mapper.Map<ToolCardViewModel>(mvcContext.GetDataSourceItem<ToolCardScModel>());
        }
    }
}