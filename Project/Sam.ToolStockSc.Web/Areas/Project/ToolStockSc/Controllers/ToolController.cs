using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Glass.Mapper.Sc.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.Mvc.Extensions;
using Sitecore.Security.Accounts;
using Sitecore.Web;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class ToolController : BaseController
    {
        private const int defaultAmount = 1;

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

        public ActionResult Issue()
        {
            var toolName = Request.QueryString["toolName"];
            int.TryParse(Request.QueryString["maxAmount"], out var maxAmount);
            Guid.TryParse(Request.QueryString["stockId"], out var stockId);

            var users = _userReferenceService.GetAllByIndex().ToList();
            
            var vm = new IssueToolViewModel
            {
                ToolName = toolName,
                StockId = stockId,
                Amount = defaultAmount,
                MaxAmount = maxAmount,
                UserName = SitecoreConstants.FakeUser.Fake.Fields["User"].Value,
                Users = users
            };

            var scModel = _mvcContext.GetDataSourceItem<IssueToUserScModel>();
            vm.ScModel = scModel;

            return View("~/Areas/Project/ToolStockSc/Views/Tool/Issue.cshtml", vm);
        }

        [HttpPost]
        public ActionResult Issue(IssueToolViewModel vm)
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor)
            {
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Issue");
            }

            if (!ModelState.IsValid || vm.Amount > vm.MaxAmount)
            {
                return Redirect(LinkManager.GetItemUrl(SitecoreConstants.PageItems.Keeper));
            }

            _toolService.IssueToUser(vm);

            return Redirect($"/{Sitecore.Context.Language.Name}/Keeper");
        }

        public ActionResult Actions()
        {
            var toolName = Request.QueryString["toolName"];
            int.TryParse(Request.QueryString["maxAmount"], out var maxAmount);
            Guid.TryParse(Request.QueryString["stockId"], out var stockId);
            
            var vm = new ActionsViewModel
            {
                ToolName = toolName,
                StockId = stockId,
                Amount = defaultAmount,
                MaxAmount = maxAmount,
                ScModel = _mvcContext.GetDataSourceItem<ActionsScModel>()
            };

            return View("~/Areas/Project/ToolStockSc/Views/Tool/Actions.cshtml", vm);
        }

        [HttpPost]
        public ActionResult GiveInForRepair(ActionsViewModel vm)
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor)
            {
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Issue");
            }

            if (!ModelState.IsValid || vm.Amount > vm.MaxAmount)
            {
                return Redirect(LinkManager.GetItemUrl(SitecoreConstants.PageItems.Keeper));
            }

            _toolService.GiveInForRepair(vm);

            return Redirect($"/{Sitecore.Context.Language.Name}/Keeper");
        }

        [HttpPost]
        public ActionResult ReturnFromRepair(ActionsViewModel vm)
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor)
            {
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Issue");
            }

            if (!ModelState.IsValid || vm.Amount > vm.MaxAmount)
            {
                return Redirect(LinkManager.GetItemUrl(SitecoreConstants.PageItems.Keeper));
            }

            _toolService.ReturnFromRepair(vm);

            return Redirect($"/{Sitecore.Context.Language.Name}/Keeper");
        }

        [HttpPost]
        public ActionResult WriteOff(ActionsViewModel vm)
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor)
            {
                return Redirect($"/{Sitecore.Context.Language.Name}/Keeper/Issue");
            }

            if (!ModelState.IsValid || vm.Amount > vm.MaxAmount)
            {
                return Redirect(LinkManager.GetItemUrl(SitecoreConstants.PageItems.Keeper));
            }

            _toolService.WriteOff(vm);

            return Redirect($"/{Sitecore.Context.Language.Name}/Keeper");
        }

        public ActionResult ReturnFromUser()
        {
            var toolName = Request.QueryString["toolName"];
            int.TryParse(Request.QueryString["maxAmount"], out var maxAmount);
            Guid.TryParse(Request.QueryString["stockId"], out var stockId);
            Guid.TryParse(Request.QueryString["userId"], out var userId);

            var users = _userReferenceService.GetAllByIndex().ToList();

            var vm = new ReturnFromUserViewModel
            {
                ToolName = toolName,
                StockId = stockId,
                Amount = defaultAmount,
                MaxAmount = maxAmount,
                UserId = userId
            };

            var scModel = _mvcContext.GetDataSourceItem<ReturnFromUserScModel>();
            vm.ScModel = scModel;

            return View("~/Areas/Project/ToolStockSc/Views/Tool/ReturnFromUser.cshtml", vm);
        }

        [HttpPost]
        public ActionResult ReturnFromUser(ReturnFromUserViewModel vm)
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor)
            {
                return ReturnFromUser();
            }

            if (!ModelState.IsValid || vm.Amount > vm.MaxAmount)
            {
                return Redirect(LinkManager.GetItemUrl(SitecoreConstants.PageItems.Keeper));
            }

            _toolService.ReturnFromUser(vm);

            return Redirect($"/{Sitecore.Context.Language.Name}/Keeper");
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