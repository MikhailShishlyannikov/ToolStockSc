using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class LogoLinkController : BaseController
    {
        public LogoLinkController(IMvcContext mvcContext) : base(mvcContext)
        {
        }
        // GET: Project/LogoLink
        public ActionResult LogoLink()
        {
            var vm = new LogoLinkViewModel();
            var scModel = _mvcContext.GetDataSourceItem<LogoLinkScModel>();

            vm.Id = scModel.Id;
            vm.Link = scModel.Link;
            vm.Logo = scModel.Logo;

            return View("~/Areas/Project/ToolStockSc/Views/LogoLink/LogoLink.cshtml", vm);
        }
    }
}