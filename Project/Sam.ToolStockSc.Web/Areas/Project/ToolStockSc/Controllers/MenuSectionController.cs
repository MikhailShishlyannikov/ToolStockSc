using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class MenuSectionController : BaseController
    {
        private readonly IMenuSectionService _menuSectionService;

        public MenuSectionController(IMvcContext mvcContext, IMenuSectionService menuSectionService) : base(mvcContext)
        {
            _menuSectionService = menuSectionService;
        }

        // GET: Project/Menu
        public ActionResult MenuSection()
        {
            var vm = _menuSectionService.Get(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/MenuSection/MenuSection.cshtml", vm);
        }
    }
}