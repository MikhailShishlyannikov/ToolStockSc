using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class WebFooterController : BaseController
    {
        private readonly IFooterService _footerService;

        public WebFooterController(IMvcContext mvcContext, IFooterService footerService) : base(mvcContext)
        {
            _footerService = footerService;
        }
        
        public ActionResult Footer()
        {
            var vm = _footerService.Get(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/Footer/Footer.cshtml", vm);
        }
    }
}