﻿using System.Collections.Generic;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ToolCountViewModel
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Manufacturer { get; set; }
        public string ToolTypeName { get; set; }

        public IList<StockCountViewModel> StockCountViewModels { get; set; }
    }
}