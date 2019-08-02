using AutoMapper;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.TableCard.Areas.Feature.TableCard.Logic.Interfaces;
using Sam.Feature.TableCard.Areas.Feature.TableCard.Models.ScModel;
using Sam.Feature.TableCard.Areas.Feature.TableCard.Models.ViewModel;
using Sam.Foundation.DependencyInjection;

namespace Sam.Feature.TableCard.Areas.Feature.TableCard.Logic.Services
{
    [Service(typeof(ITableCardService))]
    public class TableCardService : ITableCardService
    {
        private readonly IMapper _mapper;

        public TableCardService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TableCardViewModel Get(IMvcContext mvcContext)
        {
            return _mapper.Map<TableCardViewModel>(mvcContext.GetDataSourceItem<TableCardScModel>());
        }
    }
}