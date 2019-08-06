using System;
using System.Linq;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Globalization;
using Sitecore.Security.Accounts;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class ToolController : BaseController
    {
        private readonly IToolService _toolService;
        private readonly IStatusService _statusService;
        private readonly IStockService _stockService;
        private readonly IUserReferenceService _userReferenceService;
        private readonly IToolTypeService _toolTypeService;

        public ToolController(IMvcContext mvcContext, IToolService toolService, IStatusService statusService, IStockService stockService, IUserReferenceService userReferenceService, IToolTypeService toolTypeService) : base(mvcContext)
        {
            _toolService = toolService;
            _statusService = statusService;
            _stockService = stockService;
            _userReferenceService = userReferenceService;
            _toolTypeService = toolTypeService;
        }

        public ActionResult Create()
        {
            var vm = InitializeViewModel(_mvcContext.GetDataSourceItem<ToolCreatingScModel>());

            return View("~/Areas/Project/ToolStockSc/Views/Tool/Create.cshtml", vm);
        }

        [HttpPost]
        public ActionResult Create(ToolViewModel vm)
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor)
            {
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Tool-Creating");
            }

            if (!ModelState.IsValid)
            {
                foreach (var p in ModelState)
                {
                    foreach (var valueError in p.Value.Errors) _ = valueError;
                }
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Tool-Creating");

            }

            vm.Name = vm.Name.Trim();
            vm.Manufacturer = vm.Manufacturer.Trim();

            if (vm.StatusId == _statusService.Get("Issued To User")?.Id && vm.UserName == SitecoreConstants.FakeUser.Fake.Fields["User"].Value)
            {
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Tool-Creating");

            }

            if (vm.StatusId != _statusService.Get("Issued To User")?.Id && vm.UserName != SitecoreConstants.FakeUser.Fake.Fields["User"].Value)
            {
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Tool-Creating");

            }

            var checkedTool = _toolService.Get(vm.Name).FirstOrDefault();

            if (checkedTool != null && checkedTool.Manufacturer != vm.Manufacturer)
            {
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Tool-Creating");

            }

            if (checkedTool != null && checkedTool.ToolType.Id != vm.ToolTypeId)
            {
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Tool-Creating");

            }

            _toolService.Create(vm);

            return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Tool-Creating");

        }

        private ToolViewModel InitializeViewModel(ToolCreatingScModel scModel)
        {
            var vm = new ToolViewModel
            {
                Statuses = _statusService.GetAll().ToList(),
                Stocks = _stockService.GetAll().ToList(),
                Users = _userReferenceService.GetAll().ToList(),
                ToolTypes = _toolTypeService.GetAll().ToList(),
                ScModel = scModel
            };

            vm.ToolTypes.Add(new ToolTypeScModel
            {
                Id = new Guid(),
                Name = Translate.Text("Tool.ChooseToolType")
            });

            vm.Stocks.Add(new StockScModel
            {
                Id = new Guid(),
                Name = Translate.Text("Tool.ChooseStock")
            });

            vm.UserName = SitecoreConstants.FakeUser.Fake.Fields["User"].Value;

            return vm;
        }
    }
}