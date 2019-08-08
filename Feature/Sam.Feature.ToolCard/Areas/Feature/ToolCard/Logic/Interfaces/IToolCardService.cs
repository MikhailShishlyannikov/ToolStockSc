using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.ToolCard.Areas.Feature.ToolCard.Models.ViewModels;

namespace Sam.Feature.ToolCard.Areas.Feature.ToolCard.Logic.Interfaces
{
    public interface IToolCardService
    {
        ToolCardViewModel GetViewModel(IMvcContext mvcContext);
    }
}