using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class LogoLinkController : BaseController
    {
        private readonly ILogoLinkService _logoLinkService;
        public LogoLinkController(IMvcContext mvcContext, ILogoLinkService logoLinkService) : base(mvcContext)
        {
            _logoLinkService = logoLinkService;
        }

        public ActionResult LogoLink()
        {

            var vm = _logoLinkService.Get(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/LogoLink/LogoLink.cshtml", vm);
        }
    }
}