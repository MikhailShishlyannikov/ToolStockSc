using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ToolCreatingViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Amount { get; set; }

        public string ToolType { get; set; }

        public string Stock { get; set; }

        public string User { get; set; }

        public string Status { get; set; }
    }
}