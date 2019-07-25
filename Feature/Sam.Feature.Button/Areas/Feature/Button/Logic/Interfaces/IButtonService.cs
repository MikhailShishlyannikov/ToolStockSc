using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Button.Areas.Feature.Button.Models.ViewModels;

namespace Sam.Feature.Button.Areas.Feature.Button.Logic.Interfaces
{
    public interface IButtonService
    {
        ButtonViewModel Get(IMvcContext mvcContext);
    }
}
