using System;
using System.Linq;
using System.Web.Mvc;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.Mvc.Extensions;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class SearchController : BaseController
    {
        private readonly ISearchBarService _searchBarService;
        private readonly IToolService _toolService;
        private readonly IToolTypeService _toolTypeService;
        private readonly IUserReferenceService _userReferenceService;
        private readonly SitecoreService _sitecoreService = new SitecoreService(SitecoreConstants.MasterDatabase.Master);

        public SearchController(IMvcContext mvcContext, ISearchBarService searchBarService, IToolService toolService, IToolTypeService toolTypeService, IUserReferenceService userReferenceService) : base(mvcContext)
        {
            _searchBarService = searchBarService;
            _toolService = toolService;
            _toolTypeService = toolTypeService;
            _userReferenceService = userReferenceService;
        }

        // GET: Project/Search
        public ActionResult SearchBar()
        {
            var vm = _searchBarService.GetViewModel();

            return View("~/Areas/Project/ToolStockSc/Views/Search/SearchBar.cshtml", vm);
        }

        public ActionResult ToolSearch(
            int page = 1,
            int pageSize = 6,
            string searchString = "",
            string manufacturer = null,
            Guid? toolTypeId = null)
        {
            if (manufacturer == null)
            {
                manufacturer = Translate.Text("Searching.ChooseManufacturer");
            }
            
            var tools = Sitecore.Security.Accounts.User.Current.IsInRole("extranet\\Keeper")
                ? _toolService.GetAllToolCounts(true,
                    Sitecore.Security.Accounts.User.Current.Profile.GetCustomProperty("Stock").ToGuid(), searchString, manufacturer).ToList()
                : _toolService.GetAllToolCounts(false,
                    Sitecore.Security.Accounts.User.Current.Profile.GetCustomProperty("Stock").ToGuid(), searchString, manufacturer).ToList();

            foreach (var tool in tools)
            {
                var issueItem = _sitecoreService.GetItem<Item>(SitecoreConstants.PageItems.Issue);
                tool.UrlToIssue = LinkManager.GetItemUrl(issueItem);
            }

            var toolTypes = _toolTypeService.GetAllViewModels().ToList();
            var manufacturers = tools.Select(t => t.Manufacturer).Distinct().ToList();

            if (toolTypeId == new Guid() || toolTypeId == null)
            {
                toolTypes.Insert(0, new ToolTypeViewModel { Id = toolTypeId, Name = Translate.Text("Searching.ChooseToolType") });
            }
            else
            {
                tools = tools.Where(t => t.ToolTypeName == toolTypes.FirstOrDefault(tt => tt.Id == toolTypeId)?.Name).ToList();
                toolTypes.Insert(0, new ToolTypeViewModel { Id = new Guid(), Name = Translate.Text("Searching.ChooseToolType") });
            }

            manufacturers.Insert(0, Translate.Text("Searching.ChooseManufacturer"));

            var toolsPerPages = tools.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var vm = new SearchResultViewModel
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = tools.Count,
                ToolCountViewModels = toolsPerPages,
                Manufacturer = manufacturer,
                Manufacturers = manufacturers,
                toolTypeId = toolTypeId,
                ToolTypes = toolTypes
            };

            return PartialView("~/Areas/Project/ToolStockSc/Views/Search/Pagination.cshtml", vm);
        }

        public ActionResult BorrowedTools(
            int page = 1,
            int pageSize = 6,
            string searchString = "",
            string manufacturer = null,
            Guid? toolTypeId = null)
        {
            if (manufacturer == null)
            {
                manufacturer = Translate.Text("Searching.ChooseManufacturer");
            }

            var userId = _userReferenceService.Get(User.Identity.Name)?.Id ?? new Guid();

            var tools = _toolService.GetAllBorrowedToolCounts((Guid)userId, searchString, manufacturer).ToList();

            var toolTypes = _toolTypeService.GetAllViewModels().ToList();
            var manufacturers = tools.Select(t => t.Manufacturer).Distinct().ToList();

            if (toolTypeId == new Guid() || toolTypeId == null)
            {
                toolTypes.Insert(0, new ToolTypeViewModel { Id = toolTypeId, Name = Translate.Text("Searching.ChooseToolType") });
            }
            else
            {
                tools = tools.Where(t => t.ToolTypeName == toolTypes.FirstOrDefault(tt => tt.Id == toolTypeId)?.Name).ToList();
                toolTypes.Insert(0, new ToolTypeViewModel { Id = new Guid(), Name = Translate.Text("Searching.ChooseToolType") });
            }

            manufacturers.Insert(0, Translate.Text("Searching.ChooseManufacturer"));

            var toolsPerPages = tools.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var vm = new SearchResultViewModel
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = tools.Count,
                ToolCountViewModels = toolsPerPages,
                Manufacturer = manufacturer,
                Manufacturers = manufacturers,
                toolTypeId = toolTypeId,
                ToolTypes = toolTypes
            };

            return PartialView("~/Areas/Project/ToolStockSc/Views/Search/Pagination.cshtml", vm);
        }
    }
}