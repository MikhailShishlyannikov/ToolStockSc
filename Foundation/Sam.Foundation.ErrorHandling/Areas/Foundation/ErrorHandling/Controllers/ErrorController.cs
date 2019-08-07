using Sam.Foundation.GlassMapper.Controllers;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Logic.Interfaces;

namespace Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Controllers
{
    public class ErrorController : BaseController
    {
        private readonly IErrorService _errorService;

        public ErrorController(IMvcContext mvcContext, IErrorService errorService) : base(mvcContext)
        {
            _errorService = errorService;
        }

        public ActionResult Error()
        {
            var vm = _errorService.GetViewModel(_mvcContext);

            return View("~/Areas/Foundation/ErrorHandling/Views/Error/Error.cshtml", vm);
        }
    }
}