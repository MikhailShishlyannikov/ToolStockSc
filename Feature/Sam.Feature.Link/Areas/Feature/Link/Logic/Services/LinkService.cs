using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Link.Areas.Feature.Link.Logic.Interfaces;
using Sam.Feature.Link.Areas.Feature.Link.Models.ScModels;
using Sam.Feature.Link.Areas.Feature.Link.Models.ViewModels;
using Sam.Foundation.DependencyInjection;

namespace Sam.Feature.Link.Areas.Feature.Link.Logic.Services
{
    [Service(typeof(ILinkService))]
    public class LinkService : ILinkService
    {
        private readonly IMapper _mapper;

        public LinkService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public LinkViewModel Get(IMvcContext mvcContext)
        {
            return _mapper.Map<LinkViewModel>(mvcContext.GetDataSourceItem<LinkScModel>());
        }
    }
}