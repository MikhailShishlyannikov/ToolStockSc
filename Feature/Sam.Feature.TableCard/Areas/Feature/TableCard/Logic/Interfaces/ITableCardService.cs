using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.TableCard.Areas.Feature.TableCard.Models.ViewModel;

namespace Sam.Feature.TableCard.Areas.Feature.TableCard.Logic.Interfaces
{
    public interface ITableCardService
    {
        TableCardViewModel Get(IMvcContext mvcContext);
    }
}
