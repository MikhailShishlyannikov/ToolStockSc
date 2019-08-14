using System.Collections.Generic;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ToolCountViewModel
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Manufacturer { get; set; }
        public string ToolTypeName { get; set; }

        public string UrlToIssue { get; set; }
        public string UrlToRepair { get; set; }
        public string UrlToWriteOff { get; set; }
        public string UrlToMove { get; set; }
        public string UrlToReturnFromRepair { get; set; }
        public string UrlToReturnFromUser { get; set; }

        public IList<StockCountViewModel> StockCountViewModels { get; set; }
    }
}