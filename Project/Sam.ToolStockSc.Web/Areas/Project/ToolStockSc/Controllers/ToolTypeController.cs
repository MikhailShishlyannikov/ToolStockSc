using System;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Mvc.Extensions;

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

        public ActionResult ToolTypesTable()
        {
            var vm = _toolTypeService.GetAll();

            return View("~/Areas/Project/ToolStockSc/Views/ToolType/ToolTypesTable.cshtml", vm);
        }

        public ActionResult ToolTypeRename()
        {
            var id = Request.QueryString["id"].ToGuid();

            if (Sitecore.Context.PageMode.IsExperienceEditor)
            {
                var vmForEditor = new ToolTypeViewModel {Id = Guid.NewGuid(), Name = "Tool Type Name"};
                return View("~/Areas/Project/ToolStockSc/Views/ToolType/Rename.cshtml", vmForEditor);
            }

            if (id == default) return ToolTypesTable();
            var vm = _toolTypeService.Get(id);

            return View("~/Areas/Project/ToolStockSc/Views/ToolType/Rename.cshtml", vm);

        }

        [HttpPost]
        public ActionResult ToolTypeRename(ToolTypeViewModel vm)
        {
            _toolTypeService.Update(vm);

            return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/All-Tool-Types");
        }
    }
}