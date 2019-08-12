using System;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class UserCountViewModel
    {
        public Guid? UserId { get; set; }
        public string FullName { get; set; }
        public int ToolAmount { get; set; }
    }
}