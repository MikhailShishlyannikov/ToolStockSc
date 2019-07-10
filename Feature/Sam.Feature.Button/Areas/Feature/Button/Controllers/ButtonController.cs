using Glass.Mapper.Sc.Web.Mvc;
using Sam.Feature.Button.Areas.Feature.Button.Models.Rendering_Parameters;
using Sam.Feature.Button.Areas.Feature.Button.Models.ScModels;
using Sam.Feature.Button.Areas.Feature.Button.Models.ViewModels;
using Sam.Foundation.GlassMapper.Controllers;
using System.Web.Mvc;

namespace Sam.Feature.Button.Areas.Feature.Button.Controllers
{
    public class ButtonController : BaseController
    {
        public ButtonController(IMvcContext mvcContext) : base(mvcContext)
        {
        }

        public ActionResult Button()
        {
            var model = new ButtonViewModel(_mvcContext.GetDataSourceItem<ButtonScModel>(), _mvcContext.GetRenderingParameters<ButtonRP>());
            return View("~/Areas/Feature/Button/Views/Button/Button.cshtml", model);
        }
    }
}