using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Button.Areas.Feature.Button.Logic.Interfaces;
using Sam.Foundation.GlassMapper.Controllers;
using System.Web.Mvc;

namespace Sam.Feature.Button.Areas.Feature.Button.Controllers
{
    public class ButtonController : BaseController
    {
        private readonly IButtonService _buttonService;
        public ButtonController(IMvcContext mvcContext, IButtonService buttonService) : base(mvcContext)
        {
            _buttonService = buttonService;
        }

        public ActionResult Button()
        {
            var vm = _buttonService.Get(_mvcContext);
            return View("~/Areas/Feature/Button/Views/Button/Button.cshtml", vm);
        }
    }
}