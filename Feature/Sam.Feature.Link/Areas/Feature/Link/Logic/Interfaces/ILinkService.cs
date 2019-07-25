using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Link.Areas.Feature.Link.Models.ViewModels;

namespace Sam.Feature.Link.Areas.Feature.Link.Logic.Interfaces
{
    public interface ILinkService
    {
        LinkViewModel Get(IMvcContext mvcContext);
    }
}
