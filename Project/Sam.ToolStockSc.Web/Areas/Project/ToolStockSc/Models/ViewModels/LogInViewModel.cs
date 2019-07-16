using System;
using System.ComponentModel.DataAnnotations;

namespace Sam.ToolStockSc.Web.Areas.Project.ToolStockSc.Models.ViewModels
{
    public class LoginViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string EmailField { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string PasswordField { get; set; }
    }
}