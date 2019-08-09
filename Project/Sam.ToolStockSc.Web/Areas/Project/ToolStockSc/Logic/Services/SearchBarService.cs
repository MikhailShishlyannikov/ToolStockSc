using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sam.Foundation.DependencyInjection;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;
using Sitecore.Globalization;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Services
{
    [Service(typeof(ISearchBarService))]
    public class SearchBarService : ISearchBarService
    {
        private readonly IToolTypeService _toolTypeService;
        private readonly IToolService _toolService;

        public SearchBarService(IToolTypeService toolTypeService, IToolService toolService)
        {
            _toolTypeService = toolTypeService;
            _toolService = toolService;
        }

        public SearchResultViewModel GetViewModel()
        {
            var vm = new SearchResultViewModel
            {
                PageNumber = 1,
                PageSize = 6,
                searchString = "",
                Manufacturer = Translate.Text("Searching.ChooseManufacturer"),
                toolTypeId = new Guid(),
                ToolTypes = _toolTypeService.GetAllViewModels().ToList()
            };

            var allTools = _toolService.GetAll().ToList();
            var manufacturers = allTools.Select(t => t.Manufacturer).Distinct().ToList();
            vm.Manufacturers = manufacturers;

            vm.Manufacturers.Insert(0, Translate.Text("Searching.ChooseManufacturer"));
            vm.ToolTypes.Insert(0, new ToolTypeViewModel { Id = new Guid(), Name = Translate.Text("Searching.ChooseToolType") });
            return vm;
        }
    }
}