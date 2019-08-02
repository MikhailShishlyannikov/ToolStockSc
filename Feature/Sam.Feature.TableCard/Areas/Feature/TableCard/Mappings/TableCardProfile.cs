using AutoMapper;
using Sam.Feature.TableCard.Areas.Feature.TableCard.Models.ScModel;
using Sam.Feature.TableCard.Areas.Feature.TableCard.Models.ViewModel;

namespace Sam.Feature.TableCard.Areas.Feature.TableCard.Mappings
{
    public class TableCardProfile : Profile
    {
        public TableCardProfile()
        {
            CreateMap<TableCardScModel, TableCardViewModel>()
                .ReverseMap();
        }
    }
}