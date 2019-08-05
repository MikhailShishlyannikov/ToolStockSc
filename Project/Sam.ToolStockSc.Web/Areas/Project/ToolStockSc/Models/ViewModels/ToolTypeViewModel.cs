using System;
using System.Collections.Generic;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ToolTypeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ToolScModel> Tools { get; set; }

        public string UrlForRename { get; set; }
    }
}