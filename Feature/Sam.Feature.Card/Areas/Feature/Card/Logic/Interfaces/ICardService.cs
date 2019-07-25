using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Card.Areas.Feature.Card.Models.ViewModels;

namespace Sam.Feature.Card.Areas.Feature.Card.Logic.Interfaces
{
    public interface ICardService
    {
        CardViewModel Get(IMvcContext mvcContext);
    }
}
