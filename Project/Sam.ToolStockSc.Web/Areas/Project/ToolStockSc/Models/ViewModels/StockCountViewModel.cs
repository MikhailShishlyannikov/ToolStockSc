using System;
using System.Collections.Generic;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class StockCountViewModel
    {
        public Guid? StockId { get; set; }
        public string Name { get; set; }
        public int ToolAmount { get; set; }
        public int InStockToolAmount { get; set; }
        public int UnderRepairToolAmount { get; set; }
        public int IssuedToUserToolAmount { get; set; }
        public int WrittenOffToolAmount { get; set; }

        public IList<UserCountViewModel> UserCountViewModels { get; set; }
    }
}