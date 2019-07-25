using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
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
    public class MenuLinkController : BaseController
    {
        private readonly IMenuLinkService _menuLinkService;

        public MenuLinkController(IMvcContext mvcContext, IMenuLinkService menuLinkService) : base(mvcContext)
        {
            _menuLinkService = menuLinkService;
        }

        public ActionResult MenuLink()
        {
            //var vm = new MenuLinkViewModel();
            //var scModel = _mvcContext.GetDataSourceItem<MenuLinkScModel>();
            //var renderingParameter = _mvcContext.GetRenderingParameters<MenuLinkRenderingParameter>();

            //if( scModel != null)
            //{
            //    vm.Id = scModel.Id;
            //    vm.Link = scModel.Link;
            //}
            //if(renderingParameter != null)
            //{
            //    vm.Icons = new List<string>();
            //    foreach (var icon in renderingParameter.Icons)
            //    {
            //        vm.Icons.Add(icon.IconTag);
            //    }
            //}

            var vm = _menuLinkService.Get(_mvcContext);

            return View("~/Areas/Project/ToolStockSc/Views/MenuLink/MenuLink.cshtml", vm);
        }
    }
}