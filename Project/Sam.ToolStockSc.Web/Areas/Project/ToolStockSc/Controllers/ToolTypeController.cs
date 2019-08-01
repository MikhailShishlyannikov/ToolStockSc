using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class ToolTypeController : BaseController
    {
        private readonly IToolTypeService _toolTypeService;

        public ToolTypeController(IMvcContext mvcContext, IToolTypeService toolTypeService) : base(mvcContext)
        {
            _toolTypeService = toolTypeService;
        }

        public ActionResult ToolTypeCreating()
        {
            var vm = new ToolTypeCreatingViewModel
            {
                ScModel = _mvcContext.GetDataSourceItem<ToolTypeCreatingScModel>()
            };

            return View("~/Areas/Project/ToolStockSc/Views/ToolType/ToolTypeCreating.cshtml", vm);
        }

        [HttpPost]
        public ActionResult ToolTypeCreating(ToolTypeCreatingViewModel vm)
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor)
            {
                vm = new ToolTypeCreatingViewModel
                {
                    ScModel = _mvcContext.GetDataSourceItem<ToolTypeCreatingScModel>()
                };

                return View("~/Areas/Project/ToolStockSc/Views/ToolType/ToolTypeCreating.cshtml", vm);
            }

            if (!ModelState.IsValid)
            {
                vm = new ToolTypeCreatingViewModel
                {
                    ScModel = _mvcContext.GetDataSourceItem<ToolTypeCreatingScModel>()
                };

                return View("~/Areas/Project/ToolStockSc/Views/ToolType/ToolTypeCreating.cshtml", vm);
            }

            _toolTypeService.Create(vm);

            return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Tool-Type-Creating");
        }
    }
}