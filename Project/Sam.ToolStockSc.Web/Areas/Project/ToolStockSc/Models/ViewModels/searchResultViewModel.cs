using System;
using System.Collections.Generic;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class SearchResultViewModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);

        public string searchString { get; set; }
        public string Manufacturer { get; set; }
        public IList<string> Manufacturers { get; set; }
        public Guid? toolTypeId { get; set; }
        public IList<ToolTypeViewModel> ToolTypes { get; set; }

        public IList<ToolCountViewModel> ToolCountViewModels { get; set; }
    }
}