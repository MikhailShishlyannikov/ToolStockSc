using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class NavLinkController : BaseController
    {
        private readonly INavLinkService _navLinkService;

        public NavLinkController(IMvcContext mvcContext, INavLinkService navLinkService) : base(mvcContext)
        {
            _navLinkService = navLinkService;
        }
        // GET: Project/NavLink
        public ActionResult NavLink()
        {
            var vm = _navLinkService.Get(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/NavLink/NavLink.cshtml", vm);
        }
    }
}