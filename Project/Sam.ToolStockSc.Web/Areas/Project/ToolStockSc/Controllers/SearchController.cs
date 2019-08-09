using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sam.Foundation.GlassMapper.Controllers;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Controllers
{
    public class SearchController : BaseController
    {
        private readonly ISearchBarService _searchBarService;

        public SearchController(IMvcContext mvcContext, ISearchBarService searchBarService) : base(mvcContext)
        {
            _searchBarService = searchBarService;
        }

        // GET: Project/Search
        public ActionResult SearchBar()
        {
            var vm = _searchBarService.GetViewModel();

            return View("~/Areas/Project/ToolStockSc/Views/Search/SearchBar.cshtml", vm);
        }
    }
}