using System;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ReturnFromUserViewModel : BaseActionsViewModel
    {
        public Guid UserId { get; set; }

        public ReturnFromUserScModel ScModel { get; set; }
    }
}