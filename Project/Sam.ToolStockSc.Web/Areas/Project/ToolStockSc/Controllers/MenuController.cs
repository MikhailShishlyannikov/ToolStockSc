using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class MenuController : BaseController
    {
        public MenuController(IMvcContext mvcContext) : base(mvcContext)
        {
        }

        // GET: Project/Menu
        public ActionResult MenuSection()
        {
            var vm = new MenuSectionViewModel();
            var scModel = _mvcContext.GetDataSourceItem<MenuSectionScModel>();

            vm.Id = scModel.Id;
            vm.SectionName = scModel.Name;

            return View("~/Areas/Project/ToolStockSc/Views/Menu/MenuSection.cshtml", vm);
        }
    }
}