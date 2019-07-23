using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.Rendering_Parameters;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class NavLinkController : BaseController
    {
        public NavLinkController(IMvcContext mvcContext) : base(mvcContext)
        {
        }
        // GET: Project/NavLink
        public ActionResult NavLink()
        {
            var vm = new NavLinkViewModel();
            var scModel = _mvcContext.GetDataSourceItem<NavLinkScModel>();
            var renderingParameter = _mvcContext.GetRenderingParameters<NavLinkRenderingParameter>();

            if(scModel != null)
            {
                vm.Id = scModel.Id;
                vm.Link = scModel.Link;
            }
            if(renderingParameter != null)
            {
                vm.Icon = renderingParameter.Icon?.IconTag;
            }

            return View("~/Areas/Project/ToolStockSc/Views/NavLink/NavLink.cshtml", vm);
        }
    }
}