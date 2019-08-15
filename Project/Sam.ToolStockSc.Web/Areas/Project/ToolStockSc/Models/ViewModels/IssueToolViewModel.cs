using System.Collections.Generic;
using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class IssueToolViewModel : BaseActionsViewModel
    {
        public string UserName { get; set; }
        public IEnumerable<UserReferenceScModel> Users { get; set; }

        public IssueToUserScModel ScModel { get; set; }
    }
}