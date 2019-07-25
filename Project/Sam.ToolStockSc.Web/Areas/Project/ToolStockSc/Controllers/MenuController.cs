using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuSectionService _menuSectionService;

        public MenuController(IMvcContext mvcContext, IMenuSectionService menuSectionService) : base(mvcContext)
        {
            _menuSectionService = menuSectionService;
        }

        // GET: Project/Menu
        public ActionResult MenuSection()
        {
            var vm = _menuSectionService.Get(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/Menu/MenuSection.cshtml", vm);
        }
    }
}