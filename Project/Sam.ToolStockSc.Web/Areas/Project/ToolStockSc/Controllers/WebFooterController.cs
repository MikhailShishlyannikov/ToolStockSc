using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class WebFooterController : BaseController
    {
        public WebFooterController(IMvcContext mvcContext) : base(mvcContext)
        {
        }
        // GET: Project/Footer
        public ActionResult Footer()
        {
            var vm = new FooterViewModel();
            var scModel = _mvcContext.GetDataSourceItem<FooterScModel>();

            if(scModel != null)
            {
                vm.Id = scModel.Id;
                vm.Copyright = scModel.Copyright;
                vm.Design = scModel.Design;
            }

            return View("~/Areas/Project/ToolStockSc/Views/Footer/Footer.cshtml", vm);
        }
    }
}