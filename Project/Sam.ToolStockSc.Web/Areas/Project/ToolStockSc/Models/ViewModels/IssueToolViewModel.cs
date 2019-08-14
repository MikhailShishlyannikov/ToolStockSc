using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class IssueToolViewModel
    {
        public string ToolName { get; set; }
        public Guid StockId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
        public int MaxAmount { get; set; }

        public string UserName { get; set; }
        public IEnumerable<UserReferenceScModel> Users { get; set; }

        public IssueToUserScModel ScModel { get; set; }
    }
}