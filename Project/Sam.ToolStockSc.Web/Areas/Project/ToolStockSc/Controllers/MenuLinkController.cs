using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class MenuLinkController : BaseController
    {
        private readonly IMenuLinkService _menuLinkService;

        public MenuLinkController(IMvcContext mvcContext, IMenuLinkService menuLinkService) : base(mvcContext)
        {
            _menuLinkService = menuLinkService;
        }

        public ActionResult MenuLink()
        {
            var vm = _menuLinkService.Get(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/MenuLink/MenuLink.cshtml", vm);
        }
    }
}