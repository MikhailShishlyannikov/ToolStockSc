using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Button.Areas.Feature.Button.Logic.Interfaces;
using Sam.Feature.Button.Areas.Feature.Button.Models.Rendering_Parameters;
using Sam.Feature.Button.Areas.Feature.Button.Models.ScModels;
using Sam.Feature.Button.Areas.Feature.Button.Models.ViewModels;
using Sam.Foundation.DependencyInjection;

namespace Sam.Feature.Button.Areas.Feature.Button.Logic.Services
{
    [Service(typeof(IButtonService))]
    public class ButtonService : IButtonService
    {
        private readonly IMapper _mapper;

        public ButtonService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ButtonViewModel Get(IMvcContext mvcContext)
        {
            var vm = _mapper.Map<ButtonViewModel>(mvcContext.GetDataSourceItem<ButtonScModel>());
            _mapper.Map(mvcContext.GetRenderingParameters<ButtonRP>(), vm);

            return vm;
        }
    }
}