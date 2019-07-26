using Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ScModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class ChangePasswordViewModel
    {

        [Required]
        [DataType(DataType.Password)]
        [StringLength(int.MaxValue, MinimumLength = 6)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(int.MaxValue, MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

        public ChangePasswordScModel ScModel { get; set; }
    }
}