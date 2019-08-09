using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Logic.Interfaces
{
    public interface ISearchBarService
    {
        SearchResultViewModel GetViewModel();
    }
}