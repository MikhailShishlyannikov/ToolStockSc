using System;
using System.ComponentModel.DataAnnotations;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public abstract class BaseActionsViewModel
    {
        public string ToolName { get; set; }
        public Guid StockId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
        public int MaxAmount { get; set; }
    }
}