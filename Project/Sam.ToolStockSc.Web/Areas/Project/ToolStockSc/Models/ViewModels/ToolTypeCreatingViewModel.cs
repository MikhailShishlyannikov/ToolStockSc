using System.ComponentModel.DataAnnotations;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ToolTypeCreatingViewModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public ToolTypeCreatingScModel ScModel { get; set; }
    }
}