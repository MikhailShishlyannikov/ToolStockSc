using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Models.ViewModels;

namespace Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Logic.Interfaces
{
    public interface IErrorService
    {
        ErrorViewModel GetViewModel(IMvcContext mvcContext);
    }
}
